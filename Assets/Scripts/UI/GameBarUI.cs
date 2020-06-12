using TMPro;
using LittleFarmGame.Models;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


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
            _menuText.text = StringKeeper.Menu;
            _buttonMenu.onClick.AddListener(() => LoadMainMenu());
            UpdateCoinsView(GameSceneManager.PlayerInventory.Coins);
            GameSceneManager.PlayerInventory.CoinsHasChanged += UpdateCoinsView;
        }

        public void UpdateCoinsView(int currentCoinsValue)
        {
            _coinsText.text = currentCoinsValue.ToString();
        }

        private void LoadMainMenu()
        {
            SceneManager.LoadScene(0);
        }

        #endregion


    }
}