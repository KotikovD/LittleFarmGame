using UnityEngine;
using LittleFarmGame.Models;


namespace LittleFarmGame.Controllers
{
    public sealed class FarmCellController : IInitialization
    {



        #region Fields

        //[Header("Example"), Tooltip("Example")]
        //[HiddenInInspector]
        //[SerializeField]
        //[SPACE]

        #endregion


        #region Methods


        public void Initialization()
        {
            foreach (var cell in Map.InstantiatedFarmCells)
            {
                var farmCell = cell.GetComponent<FarmCell>();
                farmCell.FarmCellInteraction += ShowFarmCellUI;
                farmCell.FarmInteraction += ShowFarmUI;
            }
        }

        private void ShowFarmCellUI(FarmCell farmCell)
        {
            Debug.Log("ShowFarmCellUI");
        }

        private void ShowFarmUI(Farm farmCell)
        {
            Debug.Log("ShowFarmUI");
        }

        #endregion


    }
}