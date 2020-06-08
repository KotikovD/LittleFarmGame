using UnityEngine;


namespace LittleFarmGame.Models
{

     public abstract class Item : BaseObjectScene
    {
        public Sprite Image;
        public float SellPrice;
       public float BuyPrice;
        

        virtual public void Sell()
        {

        }

        virtual public void Buy()
        {

        }
    }
}