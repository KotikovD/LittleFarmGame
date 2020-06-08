using System;
using System.Collections.Generic;


namespace LittleFarmGame.Models
{
    public sealed class Inventory : BaseObjectScene
    {


        #region Fileds

        public event Action<int> CoinsHasChanged;
        public event Action<string> CantBuy;

        //для сохранения данных
        private Dictionary<ResourceType, int> _palyerInventory = new Dictionary<ResourceType, int>();
        private int _coins;

        #endregion


        #region Properties

        public int Coins { get => _coins; }

        #endregion
        //TODO remove
        //private void FixedUpdate()
        //{
        //    if (Input.GetKeyDown(KeyCode.DownArrow))
        //        CorrectCoins(10);

        //    if (Input.GetKeyDown(KeyCode.UpArrow))
        //        CorrectCoins(-30);
        //}

        #region Methods



        public void BuildInventory(Dictionary<ResourceType, int> DataPalyerInventory, int coins)
        {
            _palyerInventory = DataPalyerInventory;
            SetCoins(coins);

            foreach (var item in ItemsManager.FarmResources)
            {
                var itemData = item.Value.GetComponent<FarmResource>();

                foreach (var playerData in DataPalyerInventory)
                    if (itemData.ResourceType == playerData.Key)
                        itemData.PlayerCollected = playerData.Value;

                CreateInventoryCell(itemData);
            }

            foreach (var item in ItemsManager.Farms)
            {
                var itemData = item.Value.GetComponent<Farm>();
                CreateInventoryCell(itemData);
            }
        }

        private void CreateInventoryCell<T>(T value) where T : class
        {
            var newCell = Instantiate(GameResourcesPresenter.InventoryCellUI, SceneManager.InventoryContent);

            if (value.GetType().Equals(typeof(FarmResource)))
            {
                var valueData = value as FarmResource;
                newCell.SetData(valueData);
              // TODO  newCell.SellButton.onClick.AddListener(()=> CoinsHasChanged?.Invoke(_coins));
             // newCell.BuyItem +=
            }
            else if (value.GetType().Equals(typeof(Farm)))
            {
                var valueData = value as Farm;
                newCell.SetData(valueData);
            }

            
        }

        private void SetCoins(int value)
        {
            _coins = value;
            CoinsHasChanged?.Invoke(_coins);
        }

        public void CorrectCoins(int value)
        {
            var newCoins = _coins += value;
            if (newCoins > 0)
            {
                _coins = newCoins;
                CoinsHasChanged?.Invoke(_coins);
            }
            else
                CantBuy?.Invoke(StringManager.CantBuy);
        }

        public void CorrectInvenoryItem(ResourceType type, int value)
        {
            if (type == ResourceType.None) return;
            _palyerInventory[type] += value;
        }

        #endregion


    }
}