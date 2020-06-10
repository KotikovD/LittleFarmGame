using TMPro;
using LittleFarmGame.Models;
using UnityEngine.UI;
using UnityEngine;

namespace LittleFarmGame.UI
{
    public class GameBarUI : BaseUI
    {


        #region Fields

        public TextMeshProUGUI _coinsText;
        public TextMeshProUGUI _menuText;
        [SerializeField] private Button _buttonMenu;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _menuText.text = StringManager.Menu;
            _buttonMenu.onClick.AddListener(() => SceneManager.GameMenuUI.SwitchActiveGameMenu());
            UpdateCoinsView(SceneManager.PlayerInventory.Coins);
            SceneManager.PlayerInventory.CoinsHasChanged += UpdateCoinsView;
        }

        public void UpdateCoinsView(int currentCoinsValue)
        {
            _coinsText.text = currentCoinsValue.ToString();
        }

        #endregion


    }
}