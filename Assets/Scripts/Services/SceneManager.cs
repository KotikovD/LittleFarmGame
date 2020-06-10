using LittleFarmGame.UI;
using UnityEngine;
using UnityEngine.UI;


namespace LittleFarmGame.Models
{
    /// <summary>
    /// Build scene objects and keep references
    /// </summary>
    public class SceneManager : MonoBehaviour
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
        public static GameMenuUI GameMenuUI;

        #endregion


        #region SaticMethods

        public static void BuildScene()
        {
            var map = new GameObject { name = StringManager.MapName };
            Map = map.AddComponent<Map>();

            var farmItemsParent = new GameObject { name = StringManager.FarmItemsParentName };
            farmItemsParent.transform.SetParent(map.transform);
            FarmItemsParent = farmItemsParent.transform;

            PlayerInventory = GameObject.FindObjectOfType<Inventory>();
            InventoryContent = PlayerInventory.transform.GetComponentInChildren<GridLayoutGroup>().transform;

            Canvas = GameObject.Find(StringManager.CanvasName);
            
        }

        public static void BuildUI()
        {
            GameMenuUI = Instantiate(GameResourcesPresenter.GameMenuUI);
            MessageUI = Instantiate(GameResourcesPresenter.MessageUI, SceneManager.Canvas.transform);
            GameBarUI = Instantiate(GameResourcesPresenter.GameBarUI, SceneManager.Canvas.transform);
            FarmCellUI = Instantiate(GameResourcesPresenter.FarmCellUI, SceneManager.Canvas.transform);
        }

        #endregion


    }
}