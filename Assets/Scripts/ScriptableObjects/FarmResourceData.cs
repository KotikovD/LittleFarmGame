using System.IO;
using LittleFarmGame.Controllers;
using UnityEngine;


namespace LittleFarmGame.Models
{
    [CreateAssetMenu(fileName = "FarmResourceData", menuName = "CreateScriptableData/FarmResource")]
    public sealed class FarmResourceData : ScriptableObject
    {

        #region Fields

        [Header("Check for ignore fileds below and use JSON data files")]
        public bool LoadFromJSON = false;
        public string JsonDataPath;

        [Header("To create/replace JSON, needs: check this, fill fileds and start Play mode")]
        [SerializeField] private bool _createNewJSON = false;
        [Space]

        public int Id;
        public string ResourceName;
        public Sprite Image;
        public int BuyPrice;
        public int SellPrice;
        public ResourceType ResourceType;
        public float FeedWeight;

        #endregion


        #region PrivateData

        public FarmResourceData(FarmResourceJSON data)
        {
            Id = data.Id;
            ResourceName = data.ResourceName;
            BuyPrice = data.BuyPrice;
            SellPrice = data.SellPrice;
            ResourceType = data.ResourceType;
            FeedWeight = data.FeedWeight;
        }

        #endregion


        #region UnityMethods

        private void OnEnable()
        {
            var _jsonFileName = ResourceType.ToString() + ".json";

#if UNITY_EDITOR 

            JsonDataPath = Path.Combine(Application.dataPath, StringKeeper.JsonFarmResourceDataPath, _jsonFileName);
            if (_createNewJSON)
                SaveDataController.SaveItem(this, true);
#endif

#if UNITY_WEBGL
            LoadFromJSON = false;
#endif
        }

        #endregion


    }
}