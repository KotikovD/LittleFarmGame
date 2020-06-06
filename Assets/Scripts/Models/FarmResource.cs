using UnityEngine;
using UnityEngine.UI;


namespace LittleFarmGame.Models
{
    public sealed class FarmResource : Item
    {

        [SerializeField] private ResourceType _resourceType;
        [SerializeField] private float _feedWeight;


        public void SetFarmResource(FarmResourceData data)
        {
            _name = data.name;
            _image = data.Image;
            _sellPrice = data.SellPrice;
            _buyPrice = data.BuyPrice;
            _currentCount = data.CurrentCount;
            _resourceType = data.ResourceType;
            _feedWeight = data.FeedWeight;

            var image = gameObject.GetComponent<Image>();
            image.sprite = _image;
        }


        public void CollectResource()
        {

        }

    }
}