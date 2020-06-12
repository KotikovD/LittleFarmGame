using System.IO;
using LittleFarmGame.Controllers;
using UnityEngine;


namespace LittleFarmGame.Models
{
    [CreateAssetMenu(fileName = "FarmData", menuName = "CreateScriptableData/Farm")]
    public sealed class FarmData : ScriptableObject
    {

        #region Fields

        [Header("Check for ignore fileds below and use JSON data files")]
        public bool LoadFromJSON = false;
        public string JsonDataPath;

        [Header("To create/replace JSON, needs: check this, fill fileds and start Play mode")]
        [SerializeField] private bool _createNewJSON = false;
        [Space]

        [Header("Farm Data")]
        public int Id;
        public string ResourceName;
        public Sprite Image;
        public int BuyPrice;
       [HideInInspector] public int SellPrice; //Ability for improve, not use yet
        public FarmType FarmType;
        public ResourceType EatType;
        public ResourceType ProduceType;
        [Tooltip("Time between collects the resource")]
        public float TimeToCollect;
        [Range(1,10), Tooltip("TimeToCollect multiplier. Set how many times player can collect resource by one feed")]
        public int CountProductsByOneFeed;
        public int CollectWeight;

        #endregion


        #region PrivateData

        public FarmData(FarmJSON data)
        {
            Id = data.Id;
            ResourceName = data.ResourceName;
            BuyPrice = data.BuyPrice;
            SellPrice = data.SellPrice;
            FarmType = data.FarmType;
            EatType = data.EatType;
            ProduceType = data.ProduceType;
            TimeToCollect = data.TimeToCollect;
            CountProductsByOneFeed = data.CountProductsByOneFeed;
            CollectWeight = data.CollectWeight;
        }

        #endregion


        #region UnityMethods

        private void OnEnable()
        {
            var _jsonFileName = FarmType + ".json";

#if UNITY_ANDROID && !UNITY_EDITOR 
            _jsonDataPath = Path.Combine(Application.persistentDataPath, StringManager.JsonFarmDataPath, _jsonFileName);
#else
            JsonDataPath = Path.Combine(Application.dataPath, StringKeeper.JsonFarmDataPath, _jsonFileName);
            if (_createNewJSON)
                SaveDataController.SaveItem(this, true);
#endif
        }

        #endregion

    }
}