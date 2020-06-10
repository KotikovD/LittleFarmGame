using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace LittleFarmGame.Models
{
    public sealed class Farm : Item
    {
        public bool IsFed;
        public bool ReadyToCollect;
        public bool IsProducing;
        public ResourceType EatType;
        public ResourceType ProduceType;
        public float TimeToCollect;
        public int CollectWeight;
        public Image ProduceBar;
        public FarmType FarmType;
        // private FarmType _farmType;


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
            IsFed = false;
            IsProducing = true;
            for (var i = 0; i < TimeToCollect; i++)
            {
                ProduceBar.fillAmount = i / TimeToCollect;
                yield return new WaitForSeconds(1f);
            }
            ProduceBar.fillAmount = 1;
            ReadyToCollect = true;
            IsProducing = false;
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