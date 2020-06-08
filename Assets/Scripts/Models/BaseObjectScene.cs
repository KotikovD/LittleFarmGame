using UnityEngine;


namespace LittleFarmGame.Models
{
    public abstract class BaseObjectScene : MonoBehaviour
    {


        #region Fields

        [HideInInspector] public string Name;

        #endregion


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