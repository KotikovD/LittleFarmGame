using UnityEngine;


namespace LittleFarmGame.UI
{
    public abstract class BaseUI : MonoBehaviour
    {


        #region Methods

        public void SwitchOn()
        {
            gameObject.SetActive(true);
        }

        public void SwitchOff()
        {
            gameObject.SetActive(false);
        }

        #endregion


    }
}