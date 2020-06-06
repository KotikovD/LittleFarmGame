using UnityEngine;


namespace LittleFarmGame.Models
{

     public abstract class Item : BaseObjectScene
    {
        [SerializeField] protected Sprite _image;
        [SerializeField] protected float _sellPrice;
        [SerializeField] protected float _buyPrice;
        [SerializeField] protected int _currentCount;
        

        virtual public void Sell()
        {

        }

        virtual public void Buy()
        {

        }
    }
}