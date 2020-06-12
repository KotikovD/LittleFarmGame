using System;
using LittleFarmGame.Models;
using TMPro;
using UnityEngine.UI;


namespace LittleFarmGame.UI
{
    public sealed class InventoryCellUI : BaseUI
    {


        #region Fields

        public event Action<InventoryCellUI> SellItem;
        public event Action<InventoryCellUI> BuyItem;

        public TextMeshProUGUI ItemName;
        public TextMeshProUGUI CurrentCount;
        public TextMeshProUGUI SellButtonText;
        public TextMeshProUGUI BuyButtonText;
        public Image ItemIcon;
        public Button SellButton;
        public Button BuyButton;
        public ResourceType ResourceType = ResourceType.None;
        public FarmType FarmType = FarmType.None;

        #endregion
        

        #region UnityMethods

        public void SetData(FarmResource valueData)
        {
            ResourceType = valueData.ResourceType;
            ItemName.text = valueData.Name;
            ItemIcon.sprite = valueData.Image;
            CurrentCount.text = valueData.PlayerCollected.ToString();
            BuyButtonText.text = string.Concat("-", valueData.BuyPrice, Environment.NewLine, StringKeeper.BuyButton);
            SellButtonText.text = string.Concat("+", valueData.SellPrice, Environment.NewLine, StringKeeper.SellButton);
            SellButton.gameObject.SetActive(true);
            CurrentCount.gameObject.SetActive(true);
            BuyButton.onClick.AddListener(() => SellItem?.Invoke(this));
            SellButton.onClick.AddListener(() => BuyItem?.Invoke(this));
        }

        public void SetData(Farm valueData)
        {
            ItemName.text = valueData.Name;
            FarmType = valueData.FarmType;
            ItemIcon.sprite = valueData.Image;
            BuyButtonText.text = string.Concat("-", valueData.BuyPrice, Environment.NewLine, StringKeeper.BuyButton);
            SellButton.gameObject.SetActive(false);
            CurrentCount.gameObject.SetActive(false);
            BuyButton.onClick.AddListener(() => BuyItem?.Invoke(this));
        }

        #endregion


    }
}