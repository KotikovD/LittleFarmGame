using System.Collections.Generic;
using UnityEngine;


namespace LittleFarmGame.Models
{
    public class ItemsManager : MonoBehaviour
    {
        public static Dictionary<ResourceType, GameObject> FarmResources = new Dictionary<ResourceType, GameObject>();
        public static Dictionary<FarmType, GameObject> Farms = new Dictionary<FarmType, GameObject>();

        private static GameObject ItemsManagerParent = new GameObject { name = StringManager.ItemsManagerName };


        public static void BuildItems()
        {
            BuildFarmResources();
            BuildFarm();
        }

        private static void BuildFarm()
        {
            var farmDataArray = ResourcesObjectPresenter.FarmDataArray;
            var farmPrefub = ResourcesObjectPresenter.FarmPrefub;

            foreach (var data in farmDataArray)
            {
                var newInstance = Instantiate(farmPrefub);
                var newFarm = newInstance.GetComponent<Farm>();
                if (newFarm == null)
                    newFarm = newInstance.AddComponent<Farm>();
                newFarm.SetFarm(data);
 
                newFarm.SwitchOff();
                newInstance.transform.SetParent(ItemsManagerParent.transform);
                Farms.Add(data.FarmType, newInstance);
            }
        }


        private static void BuildFarmResources()
        {
            var farmResourceDataArray = ResourcesObjectPresenter.FarmResourceDataArray;
            var farmResourcePrefub = ResourcesObjectPresenter.FarmResourcePrefub;

            foreach (var data in farmResourceDataArray)
            {
                var newInstance = Instantiate(farmResourcePrefub);
                var newFarmRes = newInstance.GetComponent<FarmResource>();
                if (newFarmRes == null)
                    newFarmRes = newInstance.AddComponent<FarmResource>();
                newFarmRes.SetFarmResource(data);

                newFarmRes.SwitchOff();
                newInstance.transform.SetParent(ItemsManagerParent.transform);
                FarmResources.Add(data.ResourceType, newInstance);
            }
        }


        public static GameObject GetFarm(FarmType farmType)
        {
            foreach (var farm in Farms)
            {
                if (farmType == farm.Key)
                {
                    var newGameObject = Instantiate(farm.Value) as GameObject;
                    var newFarmRes = newGameObject.GetComponent<Farm>();
                    newGameObject.transform.SetParent(SceneObjectPresenter.FarmItemsParent);
                    newFarmRes.SwitchOn();
                    return newGameObject;
                }       
            }
            return null;
        }

        //public GameObject GetFarmResource()
        //{

        //}
    }
}