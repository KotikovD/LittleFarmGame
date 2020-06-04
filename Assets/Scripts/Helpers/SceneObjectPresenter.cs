using UnityEngine;


namespace LittleFarmGame.Models
{
    public class SceneObjectPresenter 
    {
        public static Map Map;

        public static void InitializeScene()
        {
            var map = GameObject.Find(StringManager.MapName);
            if (map != null)
                Map = map.GetComponent<Map>();
        }

    }
}