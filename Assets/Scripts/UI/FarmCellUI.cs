using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace LittleFarmGame.UI
{

    public class FarmCellUI : BaseUI
    {

        #region Fields

        public Image FarmItemImage;
        public Image BigArrow;
        public Image ProduceBar;
        public Button BuyCellButton;
        [HideInInspector] public int BuyPrice;

        [SerializeField] private TextMeshProUGUI _buttonBuyText;
        [SerializeField] private float _delayCloseUI = 3f;

        #endregion


        #region Methods

        public void SwitchEpmtyCellUI()
        {
            var enable = BuyCellButton.gameObject.activeSelf;
            _buttonBuyText.text = string.Concat("-", BuyPrice, System.Environment.NewLine, StringManager.BuyButton);
            BuyCellButton.gameObject.SetActive(!enable);
            if (!enable)
                StartCoroutine(SwitchOff(BuyCellButton.gameObject));
            else
                StopCoroutine(nameof(SwitchOff));
        }

        public void SwitchBigArrow(bool valueSwitch)
        {
            BigArrow.gameObject.SetActive(valueSwitch);
        }

        private IEnumerator SwitchOff(GameObject obj)
        {
            yield return new WaitForSeconds(_delayCloseUI);
            obj.SetActive(false);
            yield return null;
        }

        #endregion


    }
}