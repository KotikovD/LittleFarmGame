using UnityEngine;


namespace LittleFarmGame.Models
{
    public class SceneObjectPresenter
    {
        public static Map Map;
        public static Transform FarmItemsParent;

        public static void InitializeScene()
        {
            var map = new GameObject { name = StringManager.MapName };
            Map = map.AddComponent<Map>();

            var farmItemsParent = new GameObject { name = StringManager.FarmItemsParentName};
            farmItemsParent.transform.SetParent(map.transform);
            FarmItemsParent = farmItemsParent.transform;
        }

    }
}