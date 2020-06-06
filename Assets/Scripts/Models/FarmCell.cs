using UnityEngine;

namespace LittleFarmGame.Models
{
    public sealed class FarmCell : BaseObjectScene
    {
        public void SetFarmCell(bool isBusy, bool isBought, int mapPositionX, int mapPositionZ, FarmType farmItem)
        {
            IsBusy = isBusy;
            IsBought = isBought;
            MapPositionX = mapPositionX;
            MapPositionZ = mapPositionZ;
            FarmItem = farmItem;

            if (FarmItem != FarmType.None)
                AddFarmItem(FarmItem);
        }

        public FarmType FarmItem;
        public bool IsBusy = false;
        public bool IsBought = false;
        public int MapPositionX;
        public int MapPositionZ;

        private GameObject _farmItemObj;


        public void ShowSellUI()
        {

        }

        public void AddFarmItem(FarmType farmItem)
        {
            FarmItem = farmItem;
            _farmItemObj = ItemsManager.GetFarm(farmItem);
            _farmItemObj.transform.position = new Vector3(MapPositionX, 0, MapPositionZ);
        }

        public void RemoveFarmItem()
        {
            FarmItem = FarmType.None;
            Destroy(_farmItemObj);
        }

        public void ChangeFarmItem (FarmType newFarmItem)
        {
            RemoveFarmItem();
            AddFarmItem(newFarmItem);
        }
    }
}