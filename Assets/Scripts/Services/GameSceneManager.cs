using LittleFarmGame.UI;
using UnityEngine;
using UnityEngine.UI;


namespace LittleFarmGame.Models
{
    /// <summary>
    /// Add some objects to scene and keep references
    /// </summary>
    public class GameSceneManager : MonoBehaviour
    {

        #region Fileds

        public static Map Map;
        public static Transform FarmItemsParent;
        public static Inventory PlayerInventory;
        public static Transform InventoryContent;
        public static GameObject Canvas;
        public static GameBarUI GameBarUI;
        public static GameObject MessageUI;
        public static GameObject FarmCellUI;

        #endregion


        #region SaticMethods

        public static void AddScene()
        {
            var map = new GameObject { name = StringKeeper.MapName };
            Map = map.AddComponent<Map>();

            var farmItemsParent = new GameObject { name = StringKeeper.FarmItemsParentName };
            farmItemsParent.transform.SetParent(map.transform);
            FarmItemsParent = farmItemsParent.transform;

            PlayerInventory = GameObject.FindObjectOfType<Inventory>();
            InventoryContent = PlayerInventory.transform.GetComponentInChildren<HorizontalLayoutGroup>().transform;

            Canvas = GameObject.Find(StringKeeper.CanvasName);
            
        }

        public static void AddUI()
        {
            MessageUI = Instantiate(GameResourcesPresenter.MessageUI, GameSceneManager.Canvas.transform);
            GameBarUI = Instantiate(GameResourcesPresenter.GameBarUI, GameSceneManager.Canvas.transform);
            FarmCellUI = Instantiate(GameResourcesPresenter.FarmCellUI, GameSceneManager.Canvas.transform);
        }

        #endregion


    }
}