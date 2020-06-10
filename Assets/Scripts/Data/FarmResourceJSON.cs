using LittleFarmGame.Models;


namespace LittleFarmGame.Controllers
{
    public class FarmResourceJSON
    {

        #region Fields

        public int Id;
        public string ResourceName;
        public int BuyPrice;
        public int SellPrice;
        public ResourceType ResourceType;
        public float FeedWeight;

        #endregion


        #region PrivateData

        public FarmResourceJSON (FarmResourceData data)
        {
            Id = data.Id;
            ResourceName = data.ResourceName;
            BuyPrice = data.BuyPrice;
            SellPrice = data.SellPrice;
            ResourceType = data.ResourceType;
            FeedWeight = data.FeedWeight;
        }

        #endregion


    }
}