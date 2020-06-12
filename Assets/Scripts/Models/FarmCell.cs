using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using LittleFarmGame.UI;


namespace LittleFarmGame.Models
{
    public sealed class FarmCell : BaseObjectScene, IPointerDownHandler, IShouldSave
    {

        #region Fileds

        [HideInInspector] public event Action<Farm> CollectResource;
        [HideInInspector] public event Action<Farm> TryToFeed;
        [HideInInspector] public event Action<FarmCell> TryToBuyCell;
        [HideInInspector] public event Action<int> BuyNewFarm;
        [HideInInspector] public event Action IAmTheChosen;
        [HideInInspector] public event Action ShouldSave;
        [HideInInspector] public event Action<FarmCell> SerilaizeThisCell;

        [HideInInspector] public FarmType FarmItemType;
        [HideInInspector] public bool IsBusy;
        [HideInInspector] public bool IsBought;
        [HideInInspector] public int MapPositionX;
        [HideInInspector] public int MapPositionZ;
        [HideInInspector] public int CellBuyPrice;

        [SerializeField] private FarmCellUI _farmCellUI;
        [SerializeField] private Image _cellLookImage;
        [SerializeField] private Color _cellIsNotBought;
        [SerializeField] private Color _cellIsBought;
        private Farm _farmItemData;
        private FarmType _possibleFarmType;
        private int _possibleBuyPrice;
        private bool _isWaitingChoose = false;

        #endregion


        #region PrivateData

        public FarmCell(int id, bool isBusy, bool isBought, int mapPositionX, int mapPositionZ, FarmType farmItem, int cellBuyPrice)
        {
            Id = id;
            IsBusy = isBusy;
            IsBought = isBought;
            MapPositionX = mapPositionX;
            MapPositionZ = mapPositionZ;
            FarmItemType = farmItem;
            CellBuyPrice = cellBuyPrice;
        }

        #endregion


        #region UnityMethods

        private void Awake()
        {
            foreach (Transform child in _farmCellUI.transform)
                child.gameObject.SetActive(false);

            _farmCellUI.BuyCellButton.onClick.AddListener(() => TryToBuyCell?.Invoke(this));
            _farmCellUI.BuyPrice = CellBuyPrice;

            if (FarmItemType != FarmType.None)
                AddFarmItem(FarmItemType);

            _cellLookImage.color = IsBought == true ? _cellIsBought : _cellIsNotBought;

            if (!IsBought)
                TryToBuyCell += GameSceneManager.PlayerInventory.BuyCell;
        }

        #endregion


        #region Methods

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!_isWaitingChoose)
            {
                if (IsBusy)
                {
                    if (_farmItemData.ReadyToCollect)
                    {
                        CollectResource?.Invoke(_farmItemData);
                        _farmItemData.ReadyToCollect = false;
                    }

                    if (!_farmItemData.IsProducing && !_farmItemData.IsFed)
                    {
                        TryToFeed?.Invoke(_farmItemData);
                    }
                }

                if (!IsBought)
                {
                    _farmCellUI.SwitchEpmtyCellUI();
                }
            }
            else
            {
                BuyNewFarm?.Invoke(_possibleBuyPrice * -1);
                AddFarmItem(_possibleFarmType);
                IAmTheChosen?.Invoke();
            }

        }

        public void AddFarmItem(FarmType farmItem)
        {
            if (_isWaitingChoose)
                ActiveWaitingToChoose(false, 0 , FarmType.None);

            FarmItemType = farmItem;
            IsBusy = true;

            _farmItemData = gameObject.AddComponent<Farm>();
            _farmItemData.SetFarmData(ServiceLocator.Resolve<ItemsManager>().Farms[farmItem]);
            _farmCellUI.FarmItemImage.sprite = _farmItemData.Image;
            _farmItemData.ProduceBar = _farmCellUI.ProduceBar;
            _farmCellUI.FarmItemImage.gameObject.SetActive(true);

            TryToFeed += GameSceneManager.PlayerInventory.SpendFarmResource;
            CollectResource += GameSceneManager.PlayerInventory.CollectFarmResource;
            _farmItemData.StartProduce();
            SerilaizeThisCell?.Invoke(this);
              ShouldSave?.Invoke();
        }

        //Dont use yet, ability for improve
        public void RemoveFarmItem()
        {
            if (!IsBusy) return;
            FarmItemType = FarmType.None;
            IsBusy = false;
            _farmCellUI.FarmItemImage.gameObject.SetActive(false);
            Destroy(_farmCellUI.FarmItemImage.sprite);
            TryToFeed -= GameSceneManager.PlayerInventory.SpendFarmResource;
            CollectResource -= GameSceneManager.PlayerInventory.CollectFarmResource;
            SerilaizeThisCell?.Invoke(this);
            ShouldSave?.Invoke();
        }

        public void BuyThisCell()
        {
            IsBought = true;
            _cellLookImage.color = _cellIsBought;
            _farmCellUI.SwitchEpmtyCellUI();
            _farmCellUI.BuyCellButton.onClick.RemoveAllListeners();
            SerilaizeThisCell?.Invoke(this);
            ShouldSave?.Invoke();
        }

        public void ActiveWaitingToChoose(bool value, int buyPrice, FarmType farmType)
        {
            _possibleFarmType = farmType;
            _possibleBuyPrice = buyPrice;
            _isWaitingChoose = value;
            _farmCellUI.SwitchBigArrow(value);
            if (value)
                BuyNewFarm += GameSceneManager.PlayerInventory.CorrectCoins;
            else
                BuyNewFarm -= GameSceneManager.PlayerInventory.CorrectCoins;
        }

        public void SetFarmCellData(FarmCell data)
        {
            Id = data.Id;
            IsBusy = data.IsBusy;
            IsBought = data.IsBought;
            MapPositionX = data.MapPositionX;
            MapPositionZ = data.MapPositionZ;
            FarmItemType = data.FarmItemType;
            CellBuyPrice = data.CellBuyPrice;
        }

        #endregion


    }
}