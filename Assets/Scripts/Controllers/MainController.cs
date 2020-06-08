using UnityEngine;
using LittleFarmGame.Models;
using LittleFarmGame.UI;

namespace LittleFarmGame.Controllers
{

    public class MainController : MonoBehaviour
    {


        #region Fields

        public MapController MapController;
        public FarmCellController FarmCellController;
        public InventoryController InventoryController;

        #endregion


        #region UnityMethods

        private void Start()
        {
            GameResourcesPresenter.InitializeResources();
            SceneManager.BuildScene();
            ItemsManager.BuildItemsPool();
            
            MapController = new MapController();
            MapController.Initialization();

            FarmCellController = new FarmCellController();
            FarmCellController.Initialization();

            InventoryController = new InventoryController();
            InventoryController.Initialization();

            SceneManager.BuildUI();

        }

        #endregion

    }
}