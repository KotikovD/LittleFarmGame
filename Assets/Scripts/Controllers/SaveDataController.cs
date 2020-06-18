using UnityEngine;
using System.IO;
using LittleFarmGame.Models;
using Leguar.TotalJSON;
using System.Collections.Generic;


namespace LittleFarmGame.Controllers
{
    public class SaveDataController : IInitialization
    {

        #region Fileds

        public int CoinsData { get; private set; }
        public Dictionary<ResourceType, int> InventoryData { get; private set; }
        public Dictionary<int, FarmCell> FarmCellsData { get; private set; }

        #endregion


        #region Methods

        public void Initialization()
        {

#if !UNITY_WEBGL

            GameSceneManager.PlayerInventory.ShouldSave += SaveGame;

#endif

        }

        public void SaveGame()
        {
#if !UNITY_WEBGL
            SaveGame(null, null, 0);
#endif
        }

        public void SaveGame(Dictionary<ResourceType, int> inventoryData = null, Dictionary<int, FarmCell> farmCellsData = null, int coinsData = 0)
        {
            var inventoryDataJson = new JSON();
            if (inventoryData == null)
                inventoryData = GameSceneManager.PlayerInventory.GetInventory;

            foreach (var item in inventoryData)
            {
                if (item.Value == 0) continue;
                var jArray = new JArray();
                jArray.Add((int)item.Key);
                jArray.Add(item.Value);
                inventoryDataJson.Add(item.Key.ToString(), jArray);
            }

            var farmCellsDataJson = new JSON();
            if (farmCellsData == null)
                farmCellsData = GameSceneManager.Map.FarmCells;

            foreach (var farmCell in farmCellsData)
            {
                var jArray = new JArray();
                jArray.Add(farmCell.Value.Id);
                jArray.Add(farmCell.Value.IsBusy);
                jArray.Add(farmCell.Value.IsBought);
                jArray.Add(farmCell.Value.MapPositionX);
                jArray.Add(farmCell.Value.MapPositionZ);
                jArray.Add((int)farmCell.Value.FarmItemType);
                jArray.Add(farmCell.Value.CellBuyPrice);
                farmCellsDataJson.Add(farmCell.Value.Id.ToString(), jArray);
            }

            if (coinsData == 0)
                coinsData = GameSceneManager.PlayerInventory.Coins;

            var playerSavesData = new JSON();
            playerSavesData.Add("coins", coinsData);
            playerSavesData.Add("inventoryData", inventoryDataJson);
            playerSavesData.Add("farmCellsData", farmCellsData);
            var jsonString = playerSavesData.CreatePrettyString();

            File.WriteAllText(StringKeeper.JsonPlayerSavesResumeGame, jsonString);
        }

        public void LoadGameData(bool isNewGame)
        {

#if UNITY_WEBGL

            var newGameData = new WebGLNewGame();
            InventoryData = newGameData.GetGameInventoryData();
            FarmCellsData = newGameData.GetGameFarmCellsData();
            CoinsData = newGameData.GetGameCoinsData();

#else

            string jsonDataPath;
            if (isNewGame)
                jsonDataPath = StringKeeper.JsonPlayerSavesNewGame;
            else
                jsonDataPath = StringKeeper.JsonPlayerSavesResumeGame;
            var data = File.ReadAllText(jsonDataPath);
            var playerSavesData = JSON.ParseString(data);

            CoinsData = playerSavesData.GetInt("coins");

            var inventoryData = playerSavesData.GetJSON("inventoryData");
            InventoryData = new Dictionary<ResourceType, int>();
            foreach (var item in inventoryData.Keys)
            {
                var jArray = inventoryData.GetJArray(item);
                InventoryData.Add((ResourceType)jArray.GetInt(0), jArray.GetInt(1));
            }

            FarmCellsData = new Dictionary<int, FarmCell>();
            var farmCellsData = playerSavesData.GetJSON("farmCellsData");
            foreach (var item in farmCellsData.Keys)
            {
                var jArray = farmCellsData.GetJArray(item);
                FarmCellsData.Add(
                    jArray.GetInt(0),
                    new FarmCell(
                    jArray.GetInt(0),
                    jArray.GetBool(1),
                    jArray.GetBool(2),
                    jArray.GetInt(3),
                    jArray.GetInt(4),
                    (FarmType)jArray.GetInt(5),
                    jArray.GetInt(6)
                    ));
            }

#endif

        }

        public bool CheckLoadAbility()
        {
            var jsonDataPath = StringKeeper.JsonPlayerSavesResumeGame;
            return File.Exists(jsonDataPath);
        }

        public static void SaveItem(FarmResourceData data, bool prettyPrint = false)
        {
            var fileDataJSON = new FarmResourceJSON(data);
            var dataJSON = JsonUtility.ToJson(fileDataJSON, prettyPrint);
            File.WriteAllText(data.JsonDataPath, dataJSON);
        }

        public static void SaveItem(FarmData data, bool prettyPrint = false)
        {
            var fileDataJSON = new FarmJSON(data);
            var dataJSON = JsonUtility.ToJson(fileDataJSON, prettyPrint);
            File.WriteAllText(data.JsonDataPath, dataJSON);
        }

        public FarmResourceData FarmResourceLoad(string jsonDataPath)
        {
            if (File.Exists(jsonDataPath))
            {
                var data = File.ReadAllText(jsonDataPath);
                var dataJSON = JsonUtility.FromJson<FarmResourceJSON>(data);
                var farmResourceData = new FarmResourceData(dataJSON);
                return farmResourceData;
            }
            else
                return null;
        }

        public FarmData FarmLoad(string jsonDataPath)
        {
            if (File.Exists(jsonDataPath))
            {
                var data = File.ReadAllText(jsonDataPath);
                var dataJSON = JsonUtility.FromJson<FarmJSON>(data);
                var farmData = new FarmData(dataJSON);
                return farmData;
            }
            else
                return null;
        }

#endregion


    }
}