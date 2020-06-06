using UnityEngine;


namespace LittleFarmGame.Models
{
    public abstract class BaseObjectScene : MonoBehaviour
    {


        #region Fields

        [SerializeField] protected string _name;

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

        //public void SaveData()
        //{
        //    if (GetComponent<ISerializable>() != null)
        //        Object.FindObjectOfType<SerializableObjects>().PrefubsForSave.Add(gameObject);
        //}

        #endregion


    }
}