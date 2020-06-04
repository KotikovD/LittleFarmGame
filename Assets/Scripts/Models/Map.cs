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
        }

        private void FillCell(FarmCell farmCell)
        {
            var newCell = ResourcesObjectPresenter.CellPrefub;
            newCell.IsBought = farmCell.IsBought;
            newCell.IsBusy = farmCell.IsBusy;
            newCell.MapPositionX = farmCell.MapPositionX;
            newCell.MapPositionZ = farmCell.MapPositionZ;

            var position = new Vector3(farmCell.MapPositionX, 0, farmCell.MapPositionZ);
            var cellObj = Instantiate(newCell.gameObject, position, Quaternion.identity);
            cellObj.transform.SetParent(transform);
        }

        #endregion


    }
}