using UnityEngine;
using UnityEngine.UI;


namespace LittleFarmGame.Models
{
    public class SceneManager : MonoBehaviour
    {

        public static Map Map;
        public static Transform FarmItemsParent;
        public static Inventory PlayerInventory;
        public static Transform InventoryContent;
        public static GameObject Canvas;
        //public static CoinsUI CoinsUI;

        public static void BuildScene()
        {
            var map = new GameObject { name = StringManager.MapName };
            Map = map.AddComponent<Map>();

            var farmItemsParent = new GameObject { name = StringManager.FarmItemsParentName };
            farmItemsParent.transform.SetParent(map.transform);
            FarmItemsParent = farmItemsParent.transform;
            Canvas = GameObject.Find(StringManager.CanvasName);
            // var inventory = new GameObject { name = StringManager.InventoryName };
            PlayerInventory = GameObject.FindObjectOfType<Inventory>();
            InventoryContent = PlayerInventory.transform.GetComponentInChildren<GridLayoutGroup>().transform;

            // TODO PlayerInventory = GameObject.Find(StringManager.InventoryName).GetComponent<Inventory>();
            //InventoryContent = GameObject.Find(StringManager.InventoryContentFolderName).transform;
            
        }


        public static void BuildUI()
        {
            // var pose = GameResourcesPresenter.InventoryUI.GetComponent<RectTransform>();
            // var inventoryUI = Instantiate(GameResourcesPresenter.InventoryUI, SceneManager.Canvas.transform);
            //// inventoryUI.transform.SetParent(SceneManager.Canvas.transform);

            // var pose = GameResourcesPresenter.MessageUI.GetComponent<RectTransform>();
            Instantiate(GameResourcesPresenter.MessageUI, SceneManager.Canvas.transform);
            Instantiate(GameResourcesPresenter.CoinsUI, SceneManager.Canvas.transform);
        }
    }
}