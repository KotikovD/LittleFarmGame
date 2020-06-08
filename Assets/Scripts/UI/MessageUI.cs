using UnityEngine;
using System.Collections;
using TMPro;
using LittleFarmGame.Models;


namespace LittleFarmGame.UI
{
    public class MessageUI : BaseUI
    {


        #region Fields

        [SerializeField] private float _messageShowTime;
        private TextMeshProUGUI _messageText;

        #endregion


        #region Methods

        private void Awake()
        {
            _messageText = GetComponentInChildren<TextMeshProUGUI>();
            SceneManager.PlayerInventory.CantBuy += ShowMessage;
            SwitchOff();
        }


        public void ShowMessage(string messageText)
        {
            SwitchOn();
            _messageText.text = messageText;
            StopCoroutine(HideMessageUI());
            StartCoroutine(HideMessageUI());
        }

        private IEnumerator HideMessageUI()
        {
            yield return new WaitForSeconds(_messageShowTime);
            _messageText.text = string.Empty;
            SwitchOff();
        }

        #endregion


    }
}