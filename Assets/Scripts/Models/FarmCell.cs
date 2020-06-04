using UnityEngine;

namespace LittleFarmGame.Models
{
    public sealed class FarmCell : BaseObjectScene
    {
        public FarmCell(bool _isBusy, bool _isBought, int _mapPositionX, int _mapPositionZ)
        {
            IsBusy = _isBusy;
            IsBought = _isBought;
            MapPositionX = _mapPositionX;
            MapPositionZ = _mapPositionZ;
        }

        
        public Farm FarmItem;
        public bool IsBusy = false;
        public bool IsBought = false;
        public int MapPositionX;
        public int MapPositionZ;

        public void ShowSellUI()
        {

        }

    }
}