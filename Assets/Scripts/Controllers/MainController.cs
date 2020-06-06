using UnityEngine;
using LittleFarmGame.Models;


namespace LittleFarmGame.Controllers
{

    public class MainController : MonoBehaviour
    {


        #region Fields

        public MapController mapController;

        #endregion


        #region UnityMethods

        private void Start()
        {
            SceneObjectPresenter.InitializeScene();
            ResourcesObjectPresenter.InitializeResources();
            ItemsManager.BuildItems();

            mapController = new MapController();
            mapController.Initialization();
        }

        private void Update()
        {

        }


        #endregion

    }
}