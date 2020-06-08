using UnityEngine;
using UnityEngine.UI;


namespace LittleFarmGame.Models
{
    public sealed class FarmResource : Item
    {

        public ResourceType ResourceType;
        public float FeedWeight;
        public int PlayerCollected;
        private Image _cellImage;

        private void Awake()
        {
            _cellImage = gameObject.GetComponent<Image>();
        }

        public void SetFarmResource(FarmResourceData data)
        {
            Name = data.ResourceName;
            PlayerCollected = data.PlayerCollected;
            Image = data.Image;
            SellPrice = data.SellPrice;
            BuyPrice = data.BuyPrice;
            ResourceType = data.ResourceType;
            FeedWeight = data.FeedWeight;
            _cellImage.sprite = Image;
        }


        public void CollectResource()
        {
            //TODO
        }

    }
}