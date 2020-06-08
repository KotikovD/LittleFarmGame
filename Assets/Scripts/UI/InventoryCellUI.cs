using System;
using LittleFarmGame.Models;
using TMPro;
using UnityEngine.UI;


namespace LittleFarmGame.UI
{
    public sealed class InventoryCellUI : BaseUI
    {


        #region Fields

        public event Action SellItem;
        public event Action BuyItem;

        public TextMeshProUGUI ItemName;
        public TextMeshProUGUI CurrentCount;
        public TextMeshProUGUI SellButtonText;
        public TextMeshProUGUI BuyButtonText;
        public Image ItemIcon;
        public Button SellButton;
        public Button BuyButton;

        #endregion


        #region UnityMethods

        public void SetData(FarmResource valueData)
        {
            ItemName.text = valueData.Name;
            ItemIcon.sprite = valueData.Image;
            CurrentCount.text = valueData.PlayerCollected.ToString();
            BuyButtonText.text = string.Concat(StringManager.BuyButton, valueData.BuyPrice);
            SellButtonText.text = string.Concat(StringManager.SellButton, valueData.SellPrice);
            SellButton.gameObject.SetActive(true);
            CurrentCount.gameObject.SetActive(true);
            BuyButton.onClick.AddListener(() => SellItem?.Invoke());
            SellButton.onClick.AddListener(() => BuyItem?.Invoke());
        }

        public void SetData(Farm valueData)
        {
            ItemName.text = valueData.Name;
            ItemIcon.sprite = valueData.Image;
            BuyButtonText.text = string.Concat(StringManager.BuyButton, valueData.BuyPrice);
            SellButton.gameObject.SetActive(false);
            CurrentCount.gameObject.SetActive(false);
            BuyButton.onClick.AddListener(() => BuyItem?.Invoke());
        }

        #endregion


    }
}