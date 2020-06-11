using UnityEngine;
using System.IO;
using LittleFarmGame.Models;
using Leguar.TotalJSON;
using System.Collections.Generic;


namespace LittleFarmGame.Controllers
{
    public class SaveDataController : BaseController, IInitialization
    {


        #region Methods

        public void Initialization()
        {
            SceneManager.PlayerInventory.ShouldSave += SaveGame;
        }

        public void SaveGame()
        {
            var inventoryData = new JSON();
            foreach (var item in SceneManager.PlayerInventory.GetInventory)
            {
                if (item.Value == 0) continue;
                var jArray = new JArray();
                jArray.Add((int)item.Key);
                jArray.Add(item.Value);
                inventoryData.Add(item.Key.ToString(), jArray);
            }

            var farmCells = Map.InstantiatedFarmCells;
            var farmCellsData = new JSON();
            for (var i = 0; i < farmCells.Count; i++)
            {
                var jArray = new JArray();
                jArray.Add(farmCells[i].IsBusy);
                jArray.Add(farmCells[i].IsBought);
                jArray.Add(farmCells[i].MapPositionX);
                jArray.Add(farmCells[i].MapPositionZ);
                jArray.Add((int)farmCells[i].FarmItemType);
                jArray.Add(farmCells[i].CellBuyPrice);

                farmCellsData.Add(i.ToString(), jArray);
            }

            var playerSavesData = new JSON();
            playerSavesData.Add("coins", SceneManager.PlayerInventory.Coins);
            playerSavesData.Add("inventoryData", inventoryData);
            playerSavesData.Add("farmCellsData", farmCellsData);
            var jsonString = playerSavesData.CreatePrettyString();
            File.WriteAllText(StringManager.JsonPlayerSavesResumeGame, jsonString);
        }

        public void LoadGame(bool newGame = false)
        {
            var jsonDataPath = StringManager.JsonPlayerSavesResumeGame;
            if (File.Exists(jsonDataPath))
            {
                var data = File.ReadAllText(jsonDataPath);
                var playerSavesData = JSON.ParseString(data);

                var coins = playerSavesData.GetInt("coins");

                var inventoryData = playerSavesData.GetJSON("inventoryData");
                var inventory = new Dictionary<ResourceType, int>();
                foreach (var item in inventoryData.Keys)
                {
                    var jArray = inventoryData.GetJArray(item);
                    inventory.Add((ResourceType)jArray.GetInt(0), jArray.GetInt(1));
                }

                var farmCells = new List<FarmCell>();
                var farmCellsData = playerSavesData.GetJSON("farmCellsData");
                foreach (var item in farmCellsData.Keys)
                {
                    var jArray = farmCellsData.GetJArray(item);
                    farmCells.Add(new FarmCell(
                        jArray.GetBool(0),
                        jArray.GetBool(1),
                        jArray.GetInt(2),
                        jArray.GetInt(3),
                        (FarmType)jArray.GetInt(4),
                        jArray.GetInt(5)
                        ));
                }

                //TODO remove
                Debug.Log("yes! " + coins);
                foreach (var item in inventory)
                {
                    Debug.Log("type " + item.Key + " count " + item.Value);
                }
                foreach (var item in farmCells)
                    Debug.Log("type " + item.MapPositionZ);

            }
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

        public static FarmResourceData FarmResourceLoad(string jsonDataPath)
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

        public static FarmData FarmLoad(string jsonDataPath)
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