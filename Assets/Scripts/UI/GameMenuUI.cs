using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LittleFarmGame.UI
{

    public class GameMenuUI : BaseUI
    {


        #region Fields

        //[Header("Example"), Tooltip("Example")]
        //[HiddenInInspector]
        //[SerializeField]
        //[SPACE]

        #endregion


        #region Properties

        //

        #endregion



        #region Methods

        private void Awake()
        {
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