namespace LittleFarmGame
{
    /// <summary>
    /// Names, pathes, messages and other string keeper
    /// </summary>
    public static class StringManager
    {

        //Main game objects
        public static string CanvasName = "Canvas";
        public static string MapName = "Map";
        public static string FarmItemsParentName = "FarmItems";
        public static string ItemsManagerName = "ItemsManager";
        public static string InventoryName = "Inventory";
        public static string InventoryContentFolderName = "Content";

        //FarmCell
        public static string FarmCellName = "FarmCell";
        public static string FarmCellPath = "Models/Level/" + FarmCellName;

        //FarmResource
        public static string FarmResourceName = "FarmResource";
        public static string FarmResourcePath = "Models/Items/" + FarmResourceName;
        public static string FarmResourceDataFolder = "FarmResourcesData";
        public static string FarmResourceDataPath = "Data/" + FarmResourceDataFolder;

        //Farm
        public static string FarmName = "Farm";
        public static string FarmPath = "Models/Items/" + FarmName;
        public static string FarmDataFolder = "FarmData";
        public static string FarmDataPath = "Data/" + FarmDataFolder;

        //UI
        public static string InventoryUIPath = "Models/UI/Inventory";
        public static string MessageUIPath = "Models/UI/MessageUI";
        public static string InventoryCellUIPath = "Models/UI/InventoryCellUI";
        public static string CoinsUIPath = "Models/UI/GameBarUI";

        // UI text
        public static string CantBuy = "Недостаточно монеток";
        public static string SellButton = "Sell +";
        public static string BuyButton = "Buy -";
    }
}