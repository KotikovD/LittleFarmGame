using System.Collections.Generic;
using UnityEngine;


namespace LittleFarmGame.Models
{
    public sealed class Map : BaseObjectScene
    {

        #region Fileds

        /// <summary>
        /// int = Id, FarmCell = FarmCell on the map
        /// </summary>
        private Dictionary<int, FarmCell> _instantiatedFarmCells = new Dictionary<int, FarmCell>();

        #endregion


        #region Properties

        public Dictionary<int, FarmCell> FarmCells { get => _instantiatedFarmCells; }

        #endregion


        #region Methods

        public void FillCell(FarmCell farmCell)
        {
            var newCell = GameResourcesPresenter.CellPrefub;
            newCell.SetFarmCellData(farmCell);
            var position = new Vector3(farmCell.MapPositionX, 0, farmCell.MapPositionZ);
            var cellObj = Instantiate(newCell.gameObject, position, Quaternion.identity, transform);
            var instanuiedCell = cellObj.GetComponent<FarmCell>();
            _instantiatedFarmCells.Add(farmCell.Id, instanuiedCell);
        }

        public void ActiveChoseModeOnCells(int buyPrice, FarmType farmType)
        {
            if (!GameSceneManager.PlayerInventory.CorrectCoins(buyPrice * -1, true))
                return;
            SetChoseModeOnCells(true, buyPrice, farmType);
        }

        public void SetChoseModeOnCells()
        {
            SetChoseModeOnCells(false);
        }

        public void SetChoseModeOnCells(bool setValue, int buyPrice = 0, FarmType farmType = FarmType.None)
        {
            foreach (var cell in _instantiatedFarmCells)
            {
                if (cell.Value.IsBought && !cell.Value.IsBusy)
                {
                    cell.Value.ActiveWaitingToChoose(setValue, buyPrice, farmType);
                    if (setValue)
                        cell.Value.IAmTheChosen += SetChoseModeOnCells;
                    else
                    {
                        cell.Value.IAmTheChosen -= SetChoseModeOnCells;
                    }
                }
            }
        }

        public void UpdateCell(FarmCell farmCell)
        {
            _instantiatedFarmCells[farmCell.Id] = farmCell;
        }

        #endregion


    }
}