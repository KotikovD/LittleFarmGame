using LittleFarmGame.UI;
using UnityEngine;


namespace LittleFarmGame.Models
{
    public static class GameResourcesPresenter
    {
        public static FarmCell CellPrefub;
        public static GameObject FarmResourcePrefub;
        public static GameObject FarmPrefub;
        public static FarmResourceData[] FarmResourceDataArray;
        public static FarmData[] FarmDataArray;
        public static GameObject MessageUI;
        public static GameObject InventoryUI;
        public static InventoryCellUI InventoryCellUI;
        public static CoinsUI CoinsUI;

        public static void InitializeResources()
        {
            CellPrefub = Resources.Load<FarmCell>(StringManager.FarmCellPath);
            FarmResourcePrefub = Resources.Load<GameObject>(StringManager.FarmResourcePath);
            FarmResourceDataArray = Resources.LoadAll<FarmResourceData>(StringManager.FarmResourceDataPath);
            FarmPrefub = Resources.Load<GameObject>(StringManager.FarmPath);
            FarmDataArray = Resources.LoadAll<FarmData>(StringManager.FarmDataPath);
            MessageUI = Resources.Load<GameObject>(StringManager.MessageUIPath);
            InventoryUI = Resources.Load<GameObject>(StringManager.InventoryUIPath);
            InventoryCellUI = Resources.Load<InventoryCellUI>(StringManager.InventoryCellUIPath);
            CoinsUI = Resources.Load<CoinsUI>(StringManager.CoinsUIPath);
        }

    }
}