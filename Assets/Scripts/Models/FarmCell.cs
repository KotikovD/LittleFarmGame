using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace LittleFarmGame.Models
{
    public sealed class FarmCell : BaseObjectScene, IPointerDownHandler
    {

        [HideInInspector] public event Action<FarmCell> FarmCellInteraction;
        [HideInInspector] public event Action<Farm> FarmInteraction;
        public FarmType FarmItem;
        public bool IsBusy = false;
        public bool IsBought = false;
        public int MapPositionX;
        public int MapPositionZ;

        private GameObject _farmItemObj;
        private Farm _farmItemData;
        private Image _cellImage;
        [SerializeField] private Color _notBoughtColor;
        [SerializeField] private Color _boughtColor;


        public FarmCell(bool isBusy, bool isBought, int mapPositionX, int mapPositionZ, FarmType farmItem)
        {
            IsBusy = isBusy;
            IsBought = isBought;
            MapPositionX = mapPositionX;
            MapPositionZ = mapPositionZ;
            FarmItem = farmItem;
        }


        private void Awake()
        {
            _cellImage = GetComponentInChildren<Image>();

            if (FarmItem != FarmType.None)
                AddFarmItem(FarmItem);

            _cellImage.color = IsBought == true ? _boughtColor : _notBoughtColor;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (IsBusy)
                FarmInteraction?.Invoke(_farmItemData);
            else
                FarmCellInteraction?.Invoke(this);
        }

        public void AddFarmItem(FarmType farmItem)
        {
            if (IsBusy) return;
            FarmItem = farmItem;
            IsBusy = true;
            _farmItemObj = ItemsManager.GetFarm(farmItem);
            _farmItemObj.transform.position = new Vector3(MapPositionX, 0, MapPositionZ);
            _farmItemData = _farmItemObj.GetComponent<Farm>();
        }

        public void RemoveFarmItem()
        {
            if (!IsBusy) return;
            FarmItem = FarmType.None;
            IsBusy = false;
            Destroy(_farmItemObj);
        }

        public void ChangeFarmItem(FarmType newFarmItem)
        {
            RemoveFarmItem();
            AddFarmItem(newFarmItem);
        }

        
    }
}