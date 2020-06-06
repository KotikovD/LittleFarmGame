using System.Collections;
using UnityEngine;
using UnityEngine.UI;


namespace LittleFarmGame.Models
{
    public sealed class Farm : Item
    {

        FarmType _farmType;
        ResourceType _eatType;
        ResourceType _produceType;
        float _timeToCollect;
        float _collectWeight;
        float _timeReserveEveryFeed;

        private float _timeCounter = 0;
        private bool _isFed = true;


        public float EatingProgress
        {
            get { return _timeReserveEveryFeed / _timeCounter; } //TODO тут подругому отдается параметр
        }

        private void ActiveProduce()
        {
            if (_isFed)
                StartCoroutine(ProduceResource());
        }

        public void SetFarm(FarmData data)
        {
            _name = data.name;
            _image = data.Image;
            _sellPrice = data.SellPrice;
            _buyPrice = data.BuyPrice;
            _currentCount = data.CurrentCount;
            _eatType = data.EatType;
            _produceType = data.ProduceType;
            _timeToCollect = data.TimeToCollect;
            _collectWeight = data.CollectWeight;
            _timeReserveEveryFeed = data.TimeReserveEveryFeed;

            var image = gameObject.GetComponent<Image>();
            image.sprite = _image;
        }



        private IEnumerator ProduceResource()
        {
            yield return new WaitForSeconds(1f);
            _timeCounter++;
            if (_timeCounter >= _timeReserveEveryFeed)
            {
                _isFed = false;
                yield return null;
            }  
        }

        public void Feed()
        {
            _isFed = true;
        }

    }
}