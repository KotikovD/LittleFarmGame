using System.Collections.Generic;
using UnityEngine;


namespace LittleFarmGame.Models
{
    public sealed class Map : BaseObjectScene
    {


        #region Fields

        private List<FarmCell> _farmCells;

        #endregion


        #region Methods

        public void FillMap(List<FarmCell> farmCells)
        {
            _farmCells = farmCells;

            foreach (var farmCell in _farmCells)
                FillCell(farmCell);

            transform.position = PlaceMapToCenter(_farmCells);
        }

        private void FillCell(FarmCell farmCell)
        {
            var newCell = ResourcesObjectPresenter.CellPrefub;
            newCell.IsBought = farmCell.IsBought;
            newCell.IsBusy = farmCell.IsBusy;
            newCell.MapPositionX = farmCell.MapPositionX;
            newCell.MapPositionZ = farmCell.MapPositionZ;
            newCell.FarmItem = farmCell.FarmItem;

            var position = new Vector3(farmCell.MapPositionX, 0, farmCell.MapPositionZ);
            var cellObj = Instantiate(newCell.gameObject, position, Quaternion.identity) as GameObject;
            cellObj.transform.SetParent(transform);
        }

        private Vector3 PlaceMapToCenter(List<FarmCell> farmCells)
        {
            int maxX = 0;
            int maxZ = 0;

            foreach (var farmCell in farmCells)
            {
                if (farmCell.MapPositionX > maxX) maxX = farmCell.MapPositionX;
                if (farmCell.MapPositionX > maxZ) maxZ = farmCell.MapPositionZ;
            }

            var newPosition = new Vector3(maxX / 2, 0, maxZ / 2) * -1;
            return newPosition;
        }

        #endregion


    }
}