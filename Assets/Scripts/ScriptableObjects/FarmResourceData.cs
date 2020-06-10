using System.IO;
using LittleFarmGame.Controllers;
using UnityEngine;


namespace LittleFarmGame.Models
{
    [CreateAssetMenu(fileName = "FarmResourceData", menuName = "CreateScriptableData/FarmResource")]
    public sealed class FarmResourceData : ScriptableObject
    {

        #region Fields

        //UseJSON
        [Header("Check for ignore fileds below and use JSON data files")]
        public bool LoadFromJSON = false;
        public string JsonDataPath;

        [Header("To create/replace JSON, needs: check this, fill fileds and start Play mode")]
        [SerializeField] private bool CreateNewJSON = false;
        [Space]

        //Item
        public int Id;
        public string ResourceName;
        public Sprite Image;
        public int BuyPrice;
        public int SellPrice;

        //FarmResource
        public ResourceType ResourceType;
        public float FeedWeight;

        #endregion


        public FarmResourceData(FarmResourceJSON data)
        {
            Id = data.Id;
            ResourceName = data.ResourceName;
            BuyPrice = data.BuyPrice;
            SellPrice = data.SellPrice;
            ResourceType = data.ResourceType;
            FeedWeight = data.FeedWeight;
        }


        private void OnEnable()
        {
            var _jsonFileName = ResourceType.ToString() + ".json";

#if UNITY_ANDROID && !UNITY_EDITOR 
            _jsonDataPath = Path.Combine(Application.persistentDataPath, StringManager.JsonFarmResourceDataPath, _jsonFileName);
#else
            JsonDataPath = Path.Combine(Application.dataPath, StringManager.JsonFarmResourceDataPath, _jsonFileName);
#endif
            if (CreateNewJSON)
                SaveDataController.FarmResourceSave(this, true);

        }


    }
}