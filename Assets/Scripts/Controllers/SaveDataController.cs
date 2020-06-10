using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LittleFarmGame.Models;


namespace LittleFarmGame.Controllers
{
    public class SaveDataController : BaseController
    {


        #region Methods

        public static void FarmResourceSave(FarmResourceData data, bool prettyPrint = false)
        {
            var FileDataJSON = new FarmResourceJSON(data);
            var dataJSON = JsonUtility.ToJson(FileDataJSON, prettyPrint);
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


        private void CreateSerilizableFile(FarmResourceData data)
        {
            

        }

        #endregion
        

    }
}