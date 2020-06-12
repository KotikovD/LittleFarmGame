using UnityEngine;
using LittleFarmGame.Models;


namespace LittleFarmGame.Controllers
{
    public class MainController : MonoBehaviour
    {


        #region UnityMethods

        private void Start()
        {
            ServiceLocator.SetService(new SaveDataController());
            ServiceLocator.SetService(new ItemsManager());
            ServiceLocator.SetService(new MapBuilder());

            GameResourcesPresenter.InitializeResources();
            GameSceneManager.AddScene();
            ServiceLocator.Resolve<SaveDataController>().Initialization();
            ServiceLocator.Resolve<SaveDataController>().LoadGameData(SetNewOrRusameGame());
            ServiceLocator.Resolve<ItemsManager>().BuildItemsPools();
            ServiceLocator.Resolve<MapBuilder>().BuildMap();
            GameSceneManager.PlayerInventory.FillInventory();
            GameSceneManager.AddUI();
        }

        private bool SetNewOrRusameGame()
        {
            if (PlayerPrefs.HasKey("NewGame"))
            {
                var value = PlayerPrefs.GetInt("NewGame");
                return value == 1 ? true : false;
            }
            else
                return true;
        }

        #endregion


    }
}