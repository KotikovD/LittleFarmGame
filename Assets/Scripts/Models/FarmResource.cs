using UnityEngine;


namespace LittleFarmGame.Models
{
    public sealed class FarmResource : Item
    {
        public ResourceType ResourceType;
        public float FeedWeight;
        public int PlayerCollected;
        private Sprite _cellImage;


        public FarmResource(FarmResourceData data)
        {
            Name = data.ResourceName;
            Image = data.Image;
            SellPrice = data.SellPrice;
            BuyPrice = data.BuyPrice;
            ResourceType = data.ResourceType;
            FeedWeight = data.FeedWeight;
            _cellImage = Image;
        }


        public void CollectResource()
        {
            //TODO
        }

    }
}