using UnityEngine;
using System.IO;
using LittleFarmGame.Models;
using Leguar.TotalJSON;


namespace LittleFarmGame.Controllers
{
    public class SaveDataController : BaseController
    {


        #region Methods

        public static void SaveGame()
        {

            
            var inventoryData = new JSON();
            foreach (var item in SceneManager.PlayerInventory.GetInventory)
            {
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
                jArray.Add((int)farmCells[i].FarmItemType);
                jArray.Add(farmCells[i].CellBuyPrice);
                jArray.Add(farmCells[i].MapPositionX);
                jArray.Add(farmCells[i].MapPositionZ);
                jArray.Add(farmCells[i].IsBusy);
                jArray.Add(farmCells[i].IsBought);
                inventoryData.Add(i.ToString(), jArray);
            }
            
            var playerSavesData = new JSON();
            playerSavesData.Add("coins", SceneManager.PlayerInventory.Coins);
            playerSavesData.Add("inventoryData", inventoryData);
            playerSavesData.Add("farmCellsData", farmCellsData);
            var jsonString = playerSavesData.CreatePrettyString();
            File.WriteAllText(StringManager.JsonPlayerSavesResumeGame, jsonString);
        }

        public static void LoadGame(bool newGame = false)
        {
            //TODO
            var jsonDataPath = StringManager.JsonPlayerSavesResumeGame;
            if (File.Exists(jsonDataPath))
            {
                var data = File.ReadAllText(jsonDataPath);
                var playerSavesData = JSON.ParseString(data);

                var coins = playerSavesData.GetInt("coins");
                var inventoryData = playerSavesData.GetJSON("inventoryData");
  
                //foreach (var item in inventoryData.Keys)
                //{
                //    var jArray = inventoryData.GetJArray(item);
                //   ResourceType type = jArray.GetInt(0);
                //    var r = ResourceType
                //    jArray.GetInt(1);
                //}


                Debug.Log("yes! " + coins);


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