using System.Collections.Generic;
using UnityEngine;


namespace LittleFarmGame.Models
{
    public sealed class Map : BaseObjectScene
    {


        #region Fields

        public static List<FarmCell> InstantiatedFarmCells = new List<FarmCell>();

        private List<FarmCell> _farmCellsData;

        #endregion


        #region Methods

        public void FillMap(List<FarmCell> farmCells)
        {
            _farmCellsData = farmCells;

            foreach (var farmCell in _farmCellsData)
                FillCell(farmCell);

            transform.position = PlaceMapToCenter(_farmCellsData);
        }

        private void FillCell(FarmCell farmCell)
        {
            var newCell = GameResourcesPresenter.CellPrefub;
            newCell.SetFarmCell(farmCell);
            var position = new Vector3(farmCell.MapPositionX, 0, farmCell.MapPositionZ);
            var cellObj = Instantiate(newCell.gameObject, position, Quaternion.identity) as GameObject;
            cellObj.transform.SetParent(transform);
            
            InstantiatedFarmCells.Add(cellObj.GetComponent<FarmCell>());
        }

        private Vector3 PlaceMapToCenter(List<FarmCell> farmCells)
        {
            float maxX = 0f;
            float maxZ = 0f;

            foreach (var farmCell in farmCells)
            {
                if (farmCell.MapPositionX > maxX) maxX = farmCell.MapPositionX;
                if (farmCell.MapPositionX > maxZ) maxZ = farmCell.MapPositionZ;
            }

            var newPosition = new Vector3(maxX / 2, 0f, maxZ / 2) * -1;
            return newPosition;
        }

        #endregion


    }
}