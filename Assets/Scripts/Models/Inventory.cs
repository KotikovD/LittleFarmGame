using System;
using System.Collections.Generic;
using LittleFarmGame.Controllers;
using LittleFarmGame.UI;


namespace LittleFarmGame.Models
{
    public sealed class Inventory : BaseObjectScene
    {


        #region Fileds

        public event Action<int> CoinsHasChanged;
        public event Action<string> ImpossibleAction;
        public event Action ShouldSave;

        private Dictionary<ResourceType, InventoryCellUI> _iventoryResourceCells;
        private Dictionary<ResourceType, int> _palyerInventory;
        private int _coins;


        #endregion


        #region Properties

        public int Coins { get => _coins; }
        public Dictionary<ResourceType, int> GetInventory { get => _palyerInventory; }

        #endregion


        #region Methods

        public void BuildInventory(Dictionary<ResourceType, int> dataPalyerInventory, int coins)
        {
            _palyerInventory = new Dictionary<ResourceType, int>();
            _iventoryResourceCells = new Dictionary<ResourceType, InventoryCellUI>();

            SetCoins(coins);

            foreach (var item in ItemsManager.FarmResources)
            {
                var itemData = item.Value;
                if (dataPalyerInventory.ContainsKey(item.Key))
                    itemData.PlayerCollected = dataPalyerInventory[item.Key];

                _palyerInventory.Add(itemData.ResourceType, itemData.PlayerCollected);
                CreateInventoryCell(itemData);
            }

            foreach (var item in ItemsManager.Farms)
            {
                CreateInventoryCell(item.Value);
            }
        }

        private void CreateInventoryCell<T>(T value) where T : class
        {
            var newCell = Instantiate(GameResourcesPresenter.InventoryCellUI, SceneManager.InventoryContent);

            if (value.GetType().Equals(typeof(FarmResource)))
            {
                var valueData = value as FarmResource;
                newCell.SetData(valueData);
                newCell.SellButton.onClick.AddListener(() => SellFarmResource(newCell));
                newCell.BuyButton.onClick.AddListener(() => BuyFarmResource(newCell));
                _iventoryResourceCells.Add(valueData.ResourceType, newCell);
            }
            else if (value.GetType().Equals(typeof(Farm)))
            {
                var valueData = value as Farm;
                newCell.SetData(valueData);
                newCell.BuyButton.onClick.AddListener(() => SceneManager.Map.ActiveChoseModeOnCells(valueData.BuyPrice, valueData.FarmType));
            }
        }

        
        public void CorrectCoins(int value)
        {
            CorrectCoins(value, false);
        }

        public bool CorrectCoins(int value, bool justCheck)
        {
            var newCoins = _coins + value;
            if (newCoins >= 0)
            {
                if (!justCheck)
                    SetCoins(newCoins);
                return true;
            }
            else
            {
                ImpossibleAction?.Invoke(StringManager.CantBuy);
                return false;
            }
        }

        private void SetCoins(int value)
        {
            _coins = value;
            CoinsHasChanged?.Invoke(_coins);
        }

        public void CorrectCountInventoryItem(ResourceType type, int value)
        {
            if (type == ResourceType.None) return;
            _palyerInventory[type] += value;
            ShouldSave?.Invoke();
        }

        private void SellFarmResource(InventoryCellUI inventoryCell)
        {
            var farmRes = ItemsManager.FarmResources[inventoryCell.ResourceType];
            var currentCount = _palyerInventory[inventoryCell.ResourceType];
            if (currentCount > 0)
            {
                CorrectCoins(farmRes.SellPrice, false);
                currentCount -= 1;
                _palyerInventory[inventoryCell.ResourceType] = currentCount;
                inventoryCell.CurrentCount.text = currentCount.ToString();
                ShouldSave?.Invoke();
            }
        }

        private void BuyFarmResource(InventoryCellUI inventoryCell)
        {
            var farmRes = ItemsManager.FarmResources[inventoryCell.ResourceType];
            if (CorrectCoins(farmRes.BuyPrice * -1, false))
            {
                var currentCount = _palyerInventory[inventoryCell.ResourceType] += 1;
                inventoryCell.CurrentCount.text = currentCount.ToString();
                ShouldSave?.Invoke();
            }
        }

        public void BuyCell(FarmCell farmCell)
        {
            if (CorrectCoins(farmCell.CellBuyPrice * -1, false))
            {
                farmCell.BuyThisCell();
                ShouldSave?.Invoke();
            }      
        }

        public void SpendFarmResource(Farm farmData)
        {
            if (farmData.EatType == ResourceType.None)
            {
                farmData.ReloadProduce();
            }
            else
            {
                var farmRes = _palyerInventory[farmData.EatType];
                if (farmRes > 0)
                {
                    farmData.ReloadProduce();
                    farmRes = _palyerInventory[farmData.EatType] -= 1;
                    _iventoryResourceCells[farmData.EatType].CurrentCount.text = farmRes.ToString();
                    ShouldSave?.Invoke();
                }
                else
                {
                    farmData.CantFeed();
                    ImpossibleAction?.Invoke(StringManager.NeedMoreResource);
                }
            }
        }

        public void CollectFarmResource(Farm farmData)
        {
            var farmRes = _palyerInventory[farmData.ProduceType] += farmData.CollectWeight;
            _iventoryResourceCells[farmData.ProduceType].CurrentCount.text = farmRes.ToString();
            ShouldSave?.Invoke();
        }


        #endregion


    }
}