using System.IO;
using UnityEngine;

namespace LittleFarmGame
{
    /// <summary>
    /// Names, pathes, messages and other string keeper
    /// </summary>
    public static class StringKeeper
    {


        #region Fileds

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
        public static string FarmDataFolder = "FarmData";
        public static string FarmDataPath = "Data/" + FarmDataFolder;

        //UI
        public static string InventoryUIPath = "Models/UI/Inventory";
        public static string MessageUIPath = "Models/UI/MessageUI";
        public static string InventoryCellUIPath = "Models/UI/InventoryCellUI";
        public static string GameBarUIPath = "Models/UI/GameBarUI";
        public static string FarmCellUIPath = "Models/UI/FarmCellUI";
        public static string GameMenuUIPath = "Models/UI/GameMenuUI";

        //JSON
        public static string JsonFarmDataPath = Path.Combine("Resources/Data", FarmDataFolder, "JSON");
        public static string JsonFarmResourceDataPath = Path.Combine("Resources/Data", FarmResourceDataFolder, "JSON");
#if UNITY_ANDROID && !UNITY_EDITOR
        public static string JsonPlayerSavesNewGame = Path.Combine(Application.persistentDataPath, "Resources/Data/PlayerSaves/NewGame.json");
        public static string JsonPlayerSavesResumeGame = Path.Combine(Application.persistentDataPath, "Resources/Data/PlayerSaves/ResumeGame.json");
#else
        public static string JsonPlayerSavesNewGame = Path.Combine(Application.dataPath, "Resources/Data/PlayerSaves/NewGame.json");
        public static string JsonPlayerSavesResumeGame = Path.Combine(Application.dataPath, "Resources/Data/PlayerSaves/ResumeGame.json");
#endif

        // UI text
        public static string Menu = "МЕНЮ";
        public static string ResumeButtonText = "Продолжить";
        public static string NewGameButtonText = "Новая игра";
        public static string ExitGameButtonText = "Выход";
        public static string SellButton = "ПРОДАТЬ";
        public static string BuyButton = "КУПИТЬ";

        public static string CantBuyAlert = "Недостаточно монеток";
        public static string NeedMoreResourceAlert= "Нужно больше корма";

        #endregion


    }
}