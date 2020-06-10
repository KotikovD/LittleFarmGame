using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using LittleFarmGame.UI;


namespace LittleFarmGame.Models
{
    public sealed class FarmCell : BaseObjectScene, IPointerDownHandler
    {

        [HideInInspector] public event Action<Farm> CollectResource;
        [HideInInspector] public event Action<Farm> TryToFeed;
        [HideInInspector] public event Action<FarmCell> TryToBuyCell;
        [HideInInspector] public event Action<int> BuyNewFarm;
        [HideInInspector] public event Action IAmTheChosen;

        [HideInInspector] public FarmType FarmItemType;
        [HideInInspector] public bool IsBusy = false;
        [HideInInspector] public bool IsBought = false;
        [HideInInspector] public int MapPositionX;
        [HideInInspector] public int MapPositionZ;

        public int CellBuyPrice;
        private Farm _farmItemData;
        [SerializeField] private FarmCellUI _farmCellUI;
        [SerializeField] private Image _cellLookImage;
        [SerializeField] private Color _cellIsNotBought;
        [SerializeField] private Color _cellIsBought;
        private FarmType _possibleFarmType = FarmType.None;
        private int _possibleBuyPrice;
        private bool _isWaitingChoose = false;

        public FarmCell(bool isBusy, bool isBought, int mapPositionX, int mapPositionZ, FarmType farmItem, int cellBuyPrice)
        {
            IsBusy = isBusy;
            IsBought = isBought;
            MapPositionX = mapPositionX;
            MapPositionZ = mapPositionZ;
            FarmItemType = farmItem;
            CellBuyPrice = cellBuyPrice;
        }

        public void SetFarmCell(FarmCell data)
        {
            IsBusy = data.IsBusy;
            IsBought = data.IsBought;
            MapPositionX = data.MapPositionX;
            MapPositionZ = data.MapPositionZ;
            FarmItemType = data.FarmItemType;
            CellBuyPrice = data.CellBuyPrice;
        }

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
                TryToBuyCell += SceneManager.PlayerInventory.BuyCell;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!_isWaitingChoose)
            {
                if (IsBusy)
                {
                    if (_farmItemData.ReadyToCollect)
                    {
                        CollectResource?.Invoke(_farmItemData);
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
            if (IsBusy) return;
            if (_isWaitingChoose)
                ActiveWaitingToChoose(false, 0 , FarmType.None);

            FarmItemType = farmItem;
            IsBusy = true;

            _farmItemData = gameObject.AddComponent<Farm>();
            _farmItemData.SetFarmData(ItemsManager.Farms[farmItem]);

            _farmCellUI.FarmItemImage.sprite = _farmItemData.Image;
            _farmItemData.ProduceBar = _farmCellUI.ProduceBar;
            _farmCellUI.FarmItemImage.gameObject.SetActive(true);

            TryToFeed += SceneManager.PlayerInventory.SpendFarmResource;
            CollectResource += SceneManager.PlayerInventory.CollectFarmResource;
            _farmItemData.StartProduce();
        }

        public void RemoveFarmItem()
        {
            if (!IsBusy) return;
            FarmItemType = FarmType.None;
            IsBusy = false;
            _farmCellUI.FarmItemImage.gameObject.SetActive(false);
            Destroy(_farmCellUI.FarmItemImage.sprite);
            TryToFeed -= SceneManager.PlayerInventory.SpendFarmResource;
            CollectResource -= SceneManager.PlayerInventory.CollectFarmResource;
        }

        public void BuyThisCell()
        {
            IsBought = true;
            _cellLookImage.color = _cellIsBought;
            _farmCellUI.SwitchEpmtyCellUI();
            _farmCellUI.BuyCellButton.onClick.RemoveAllListeners();
        }

        public void ActiveWaitingToChoose(bool value, int buyPrice, FarmType farmType)
        {
            _possibleFarmType = farmType;
            _possibleBuyPrice = buyPrice;
            _isWaitingChoose = value;
            _farmCellUI.SwitchBigArrow(value);
            if (value)
                BuyNewFarm += SceneManager.PlayerInventory.CorrectCoins;
            else
                BuyNewFarm -= SceneManager.PlayerInventory.CorrectCoins;
        }

    }
}