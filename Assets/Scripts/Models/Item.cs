using UnityEngine;


namespace LittleFarmGame.Models
{
    public abstract class Item : BaseObjectScene
    {
        public int Id;
        public int SellPrice;
        public int BuyPrice;
        public Sprite Image;

    }
}