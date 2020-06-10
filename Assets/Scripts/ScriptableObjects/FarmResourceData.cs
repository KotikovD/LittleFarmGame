using UnityEngine;


namespace LittleFarmGame.Models
{
    [CreateAssetMenu(fileName = "FarmResourceData", menuName = "CreateScriptableData/FarmResource")]
    public sealed class FarmResourceData : ScriptableObject
    {

        #region Fields

        [Header("Farm Resource Data")]
        //Item
        public int Id;
        public string ResourceName;
        public Sprite Image;
        public int BuyPrice;
        public int SellPrice;

        //FarmResource
        public ResourceType ResourceType;
        //public int PlayerCollected;
        public float FeedWeight;

        #endregion

        
    }
}