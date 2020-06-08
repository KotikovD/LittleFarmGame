using TMPro;
using LittleFarmGame.Models;


namespace LittleFarmGame.UI
{
    public class CoinsUI : BaseUI
    {


        #region Fields

        public TextMeshProUGUI _coinsText;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _coinsText = GetComponentInChildren<TextMeshProUGUI>();
            SceneManager.PlayerInventory.CoinsHasChanged += UpdateCoinsView;
        }


        public void UpdateCoinsView(int currentCoinsValue)
        {
            _coinsText.text = currentCoinsValue.ToString();
        }


        #endregion


    }
}