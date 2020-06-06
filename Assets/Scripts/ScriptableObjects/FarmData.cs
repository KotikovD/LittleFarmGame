using UnityEngine;


namespace LittleFarmGame.Models
{
    [CreateAssetMenu(fileName = "FarmData", menuName = "CreateScriptableData/Farm")]
    public sealed class FarmData : ScriptableObject
    {

        #region Fields

        [Header("Farm Data")]
        //Item
        public string ResourceName;
        public Sprite Image;
        public float BuyPrice;
        public float SellPrice;
        [Tooltip("The number the player has available of these resource")]
        public int CurrentCount;

        //Farm
        public FarmType FarmType;
        public ResourceType EatType;
        public ResourceType ProduceType;
        public float TimeToCollect;
        public float CollectWeight;
        public float TimeReserveEveryFeed;

        #endregion


    }
}