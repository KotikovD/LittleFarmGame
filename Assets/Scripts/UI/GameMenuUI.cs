using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using LittleFarmGame.Controllers;

namespace LittleFarmGame.UI
{

    public class GameMenuUI : BaseUI
    {


        #region Fields

        [SerializeField] private Button _newGame;
        [SerializeField] private Button _loadGame;
        [SerializeField] private Button _rusame;

        #endregion


        #region Methods

        private void Awake()
        {
            //TODO text from manager
          //  _newGame.onClick.AddListener(() => SaveDataController.SaveGame());
            SwitchOff();
        }


        public void SwitchActiveGameMenu()
        {
            var switchValue = gameObject.activeSelf;
            if (switchValue)
            {
                SwitchOff();
                Time.timeScale = 1;
            }  
            else
            {
                SwitchOn();
                Time.timeScale = 0;
            }
                

        }

        #endregion


    }
}