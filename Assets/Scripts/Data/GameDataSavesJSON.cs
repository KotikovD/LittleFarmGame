using System.Collections.Generic;
using LittleFarmGame.Models;
using System;
using UnityEngine;

namespace LittleFarmGame.Controllers
{
   // [Serializable]
    public class GameDataSavesJSON
    {

        #region Fields
        public int _coins;
        //public List<FarmCell> _farmCells = new List<FarmCell>();
        //Dictionary<ResourceType, int> _palyerInventory = new Dictionary<ResourceType, int>();

        

        #endregion


        #region PrivateData

        public void SetGameDataSavesJSON(List<FarmCell> farmCells, Dictionary<ResourceType, int> playerInventory, int coins)
        {
            //_farmCells = farmCells;

            //_palyerInventory = playerInventory;
            ////foreach (var item in palyerInventory)
            ////{
            ////    _palyerInventory.Add(new PlayerInventoryJSON(item.Key, item.Value));

            ////   // Debug.Log(item.Key);
            ////}

            _coins = coins;
        }

        #endregion

    }
}