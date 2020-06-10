using LittleFarmGame.Models;


namespace LittleFarmGame.Controllers
{
    public class FarmJSON
    {


        #region Fields

        public int Id;
        public string ResourceName;
        public int BuyPrice;
        public int SellPrice;
        public FarmType FarmType;
        public ResourceType EatType;
        public ResourceType ProduceType;
        public float TimeToCollect;
        public int CountProductsByOneFeed;
        public int CollectWeight;

        #endregion


        #region PrivateData

        public FarmJSON(FarmData data)
        {
            Id = data.Id;
            ResourceName = data.ResourceName;
            BuyPrice = data.BuyPrice;
            SellPrice = data.SellPrice;
            FarmType = data.FarmType;
            EatType = data.EatType;
            ProduceType = data.ProduceType;
            TimeToCollect = data.TimeToCollect;
            CountProductsByOneFeed = data.CountProductsByOneFeed;
            CollectWeight = data.CollectWeight;
        }

        #endregion


    }
}