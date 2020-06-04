using System.Collections;
using UnityEngine;


namespace LittleFarmGame.Models
{
    public sealed class Farm : Item
    {

        FarmType _farmType;
        ResourceType _resourceType;
        ResourceType _produceType;
        float _timeToCollect;
        float _collectWeight;
        float _eatingSpeed;

        private float _timeCounter = 0;
        private bool _isFed = true;


        public float EatingProgress
        {
            get { return _eatingSpeed / _timeCounter; } //TODO тут подругому отдается параметр
        }

        private void Start()
        {
            if (_isFed)
                StartCoroutine(ProduceResource());
        }

        private IEnumerator ProduceResource()
        {
            yield return new WaitForSeconds(1f);
            _timeCounter++;
            if (_timeCounter >= _eatingSpeed)
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