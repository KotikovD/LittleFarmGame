using System.Collections.Generic;
using LittleFarmGame.Controllers;
using UnityEngine;


namespace LittleFarmGame.Models
{
    public sealed class MapBuilder : BaseObjectScene
    {


        #region Methods

        public void BuildMap()
        {
            var farmCells = ServiceLocator.Resolve<SaveDataController>().FarmCellsData;
            var map = GameSceneManager.Map;

            foreach (var farmCell in farmCells)
                map.FillCell(farmCell.Value);

            map.transform.position = PlaceMapToCenter(farmCells);

            foreach (var cell in map.FarmCells)
            {
                cell.Value.ShouldSave += ServiceLocator.Resolve<SaveDataController>().SaveGame;
                cell.Value.SerilaizeThisCell += map.UpdateCell;
            }
        }

        private Vector3 PlaceMapToCenter(Dictionary<int, FarmCell> farmCells)
        {
            float maxX = 0f;
            float maxZ = 0f;
            foreach (var farmCell in farmCells)
            {
                if (farmCell.Value.MapPositionX > maxX) maxX = farmCell.Value.MapPositionX;
                if (farmCell.Value.MapPositionX > maxZ) maxZ = farmCell.Value.MapPositionZ;
            }
            var newPosition = new Vector3(maxX / 2, 0f, maxZ / 2) * -1;
            return newPosition;
        }

        #endregion


    }
}