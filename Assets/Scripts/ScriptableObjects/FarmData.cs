using UnityEngine;


namespace LittleFarmGame.Models
{
    [CreateAssetMenu(fileName = "FarmData", menuName = "CreateScriptableData/Farm")]
    public sealed class FarmData : ScriptableObject
    {

        #region Fields

        [Header("Farm Data")]
        //Item
        public int Id;
        public string ResourceName;
        public Sprite Image;
        public int BuyPrice;
        public int SellPrice;

        //Farm
        public FarmType FarmType;
        public ResourceType EatType;
        public ResourceType ProduceType;
        public float TimeToCollect;
        public int CollectWeight;

        #endregion


    }
}