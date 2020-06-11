using System;
using System.Collections.Generic;
using LittleFarmGame.UI;


namespace LittleFarmGame.Models
{
    public sealed class Inventory : BaseObjectScene
    {


        #region Fileds

        public event Action<int> CoinsHasChanged;
        public event Action<string> ImpossibleAction;

        private Dictionary<ResourceType, InventoryCellUI> _iventoryResourceCells = new Dictionary<ResourceType, InventoryCellUI>();
        private Dictionary<ResourceType, int> _palyerInventory = new Dictionary<ResourceType, int>();
        private int _coins;

        
        #endregion

        public int Coins { get => _coins; }
        public Dictionary<ResourceType, int> GetInventory { get => _palyerInventory; }

        #region Methods

        public void BuildInventory(Dictionary<ResourceType, int> DataPalyerInventory, int coins)
        {
            _palyerInventory = DataPalyerInventory;
            SetCoins(coins);

            foreach (var item in ItemsManager.FarmResources)
            {
                var itemData = item.Value;

                foreach (var playerData in DataPalyerInventory)
                    if (itemData.ResourceType == playerData.Key)
                        itemData.PlayerCollected = playerData.Value;
                CreateInventoryCell(itemData);
            }

            foreach (var item in ItemsManager.Farms)
            {
                CreateInventoryCell(item.Value);
            }
        }

        /// <summary>
        /// Send counts resources and coins data to JSON TODO
        /// </summary>
        private void SaveInventoryData()
        {

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
                newCell.BuyButton.onClick.AddListener(() => ActiveChoseModeOnCells(valueData.BuyPrice, valueData.FarmType));
            }
        }

        private void SetCoins(int value)
        {
            _coins = value;
            CoinsHasChanged?.Invoke(_coins);
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
                {
                    _coins = newCoins;
                    CoinsHasChanged?.Invoke(_coins);
                }
                return true;
            }
            else
            {
                ImpossibleAction?.Invoke(StringManager.CantBuy);
                return false;
            }
        }

        public void CorrectInvenoryItem(ResourceType type, int value)
        {
            if (type == ResourceType.None) return;
            _palyerInventory[type] += value;
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
            }
        }

        private void BuyFarmResource(InventoryCellUI inventoryCell)
        {
            var farmRes = ItemsManager.FarmResources[inventoryCell.ResourceType];
            if (CorrectCoins(farmRes.BuyPrice * -1, false))
            {
                var currentCount = _palyerInventory[inventoryCell.ResourceType] += 1;
                inventoryCell.CurrentCount.text = currentCount.ToString();
            }
        }

        public void BuyCell(FarmCell farmCell)
        {
            if (CorrectCoins(farmCell.CellBuyPrice * -1, false))
                farmCell.BuyThisCell();
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
        }


        //убрать эти три метода из инвенторя  TODO
        public void ActiveChoseModeOnCells(int buyPrice, FarmType farmType)
        {
            if (!CorrectCoins(buyPrice * -1, true)) return;
            SetChoseModeOnCells(true, buyPrice, farmType);

        }

        public void SetChoseModeOnCells()
        {
            SetChoseModeOnCells(false);
        }

        public void SetChoseModeOnCells(bool setValue, int buyPrice = 0, FarmType farmType = FarmType.None)
        {
            foreach (var cell in Map.InstantiatedFarmCells)
            {
                if (cell.IsBought && !cell.IsBusy)
                {
                    cell.ActiveWaitingToChoose(setValue, buyPrice, farmType);
                    if (setValue)
                        cell.IAmTheChosen += SetChoseModeOnCells;
                    else
                        cell.IAmTheChosen -= SetChoseModeOnCells;
                }
            }
        }

        #endregion


    }
}