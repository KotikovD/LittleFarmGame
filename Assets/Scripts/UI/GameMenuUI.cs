using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace LittleFarmGame.UI
{
    public class GameMenuUI : BaseUI
    {


        #region Fields

        [SerializeField] private Button _newGame;
        [SerializeField] private Button _rusameOrLoad;
        [SerializeField] private Button _exitGame;
        [SerializeField] private TextMeshProUGUI _newGameText;
        [SerializeField] private TextMeshProUGUI _rusameOrLoadText;
        [SerializeField] private TextMeshProUGUI _exitText;
        [SerializeField] private GameObject _loadScreen;
        
        #endregion


        #region UnityMethods

        private void Awake()
        {
            _newGameText.text = StringKeeper.NewGameButtonText;
            _rusameOrLoadText.text = StringKeeper.ResumeButtonText;
            _exitText.text = StringKeeper.ExitGameButtonText;

            _exitGame.onClick.AddListener(() => QuitGame());
            _rusameOrLoad.onClick.AddListener(() => StartCoroutine(LoadNewGame(false)));
            _newGame.onClick.AddListener(() => StartCoroutine(LoadNewGame(true)));

            _loadScreen.SetActive(false);
        }

        #endregion


        #region Method

       private IEnumerator LoadNewGame(bool isNewGame)
        {
            var i = isNewGame == true ? 1 : 0;
            PlayerPrefs.SetInt("NewGame", i);
            AsyncOperation operation = SceneManager.LoadSceneAsync(1);
            _loadScreen.SetActive(true);
            yield return null;
        }

        private void QuitGame()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        #endregion


    }
}