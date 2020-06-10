using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace LittleFarmGame.Models
{
    public sealed class Farm : Item
    {
        private const int ANIMATION_SMOOTH = 20;

        public bool IsFed;
        public bool ReadyToCollect;
        public bool IsProducing;
        public ResourceType EatType;
        public ResourceType ProduceType;
        public float TimeToCollect;
        public int CollectWeight;
        public Image ProduceBar;
        public FarmType FarmType;
        public int CountProductsByOneFeed;


        public Farm(FarmData data)
        {
            Name = data.ResourceName;
            Image = data.Image;
            FarmType = data.FarmType;
            SellPrice = data.SellPrice;
            BuyPrice = data.BuyPrice;
            EatType = data.EatType;
            ProduceType = data.ProduceType;
            TimeToCollect = data.TimeToCollect;
            CollectWeight = data.CollectWeight;
            CountProductsByOneFeed = data.CountProductsByOneFeed;
        }

        public void SetFarmData(Farm data)
        {
            Name = data.Name;
            Image = data.Image;
            SellPrice = data.SellPrice;
            BuyPrice = data.BuyPrice;
            EatType = data.EatType;
            ProduceType = data.ProduceType;
            TimeToCollect = data.TimeToCollect;
            CollectWeight = data.CollectWeight;
            CountProductsByOneFeed = data.CountProductsByOneFeed;
            IsFed = true;
            IsProducing = false;
            ReadyToCollect = false;
        }

        public void StartProduce()
        {

            if (!IsFed) return;

            StopCoroutine(ProducingResource());
            StartCoroutine(ProducingResource());
        }

        private IEnumerator ProducingResource()
        {

            IsProducing = true;
            for (var z = 0; z < CountProductsByOneFeed; z++)
            {
                for (var i = 0; i < TimeToCollect * ANIMATION_SMOOTH; i++)
                {
                    ProduceBar.fillAmount = i / TimeToCollect / ANIMATION_SMOOTH;
                    yield return new WaitForSeconds(1f / ANIMATION_SMOOTH);
                }
                ProduceBar.fillAmount = 1;
                ReadyToCollect = true;
                if (CountProductsByOneFeed - 1 != z)
                    yield return new WaitUntil(() => ReadyToCollect == false);
            }
            IsProducing = false;
            IsFed = false;
            yield return null;
        }

        public void ReloadProduce()
        {
            IsFed = true;
            ReadyToCollect = false;
            StartProduce();
        }

        public void CantFeed()
        {
            ReadyToCollect = false;
        }

    }
}