using LittleFarmGame.UI;
using UnityEngine;


namespace LittleFarmGame.Models
{
    public static class GameResourcesPresenter
    {

        #region Fileds

        public static FarmCell CellPrefub;
        public static FarmResourceData[] FarmResourceDataArray;
        public static FarmData[] FarmDataArray;
        public static GameObject MessageUI;
        public static GameObject InventoryUI;
        public static InventoryCellUI InventoryCellUI;
        public static GameBarUI GameBarUI;
        public static GameObject FarmCellUI;
        public static GameMenuUI GameMenuUI;


        #endregion


        #region Methods

        public static void InitializeResources()
        {
            CellPrefub = Resources.Load<FarmCell>(StringManager.FarmCellPath);
            FarmResourceDataArray = Resources.LoadAll<FarmResourceData>(StringManager.FarmResourceDataPath);
            FarmDataArray = Resources.LoadAll<FarmData>(StringManager.FarmDataPath);
            MessageUI = Resources.Load<GameObject>(StringManager.MessageUIPath);
            InventoryUI = Resources.Load<GameObject>(StringManager.InventoryUIPath);
            InventoryCellUI = Resources.Load<InventoryCellUI>(StringManager.InventoryCellUIPath);
            GameBarUI = Resources.Load<GameBarUI>(StringManager.GameBarUIPath);
            FarmCellUI = Resources.Load<GameObject>(StringManager.FarmCellUIPath);
            GameMenuUI = Resources.Load<GameMenuUI>(StringManager.GameMenuUIPath);
        }

        #endregion


    }
}