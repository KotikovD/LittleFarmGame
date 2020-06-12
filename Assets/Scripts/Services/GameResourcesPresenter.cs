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
            CellPrefub = Resources.Load<FarmCell>(StringKeeper.FarmCellPath);
            FarmResourceDataArray = Resources.LoadAll<FarmResourceData>(StringKeeper.FarmResourceDataPath);
            FarmDataArray = Resources.LoadAll<FarmData>(StringKeeper.FarmDataPath);
            MessageUI = Resources.Load<GameObject>(StringKeeper.MessageUIPath);
            InventoryUI = Resources.Load<GameObject>(StringKeeper.InventoryUIPath);
            InventoryCellUI = Resources.Load<InventoryCellUI>(StringKeeper.InventoryCellUIPath);
            GameBarUI = Resources.Load<GameBarUI>(StringKeeper.GameBarUIPath);
            FarmCellUI = Resources.Load<GameObject>(StringKeeper.FarmCellUIPath);
            GameMenuUI = Resources.Load<GameMenuUI>(StringKeeper.GameMenuUIPath);
        }

        #endregion


    }
}