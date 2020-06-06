using UnityEngine;


namespace LittleFarmGame.Models
{
    [CreateAssetMenu(fileName = "FarmResourceData", menuName = "CreateScriptableData/FarmResource")]
    public sealed class FarmResourceData : ScriptableObject
    {

        #region Fields

        [Header("Farm Resource Data")]
        //Item
        public string ResourceName;
        public Sprite Image;
        public float BuyPrice;
        public float SellPrice;
        [Tooltip("The number the player has available of these resource")]
        public int CurrentCount;

        //FarmResource
        public ResourceType ResourceType;
        public float FeedWeight;

        #endregion


    }
}