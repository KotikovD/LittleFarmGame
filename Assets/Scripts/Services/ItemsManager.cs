using System.Collections.Generic;
using LittleFarmGame.Controllers;
using UnityEngine;


namespace LittleFarmGame.Models
{
    public class ItemsManager : MonoBehaviour
    {


        #region Fileds

        public static Dictionary<ResourceType, FarmResource> FarmResources = new Dictionary<ResourceType, FarmResource>();
        public static Dictionary<FarmType, Farm> Farms = new Dictionary<FarmType, Farm>();

        // private static GameObject ItemsManagerParent = new GameObject { name = StringManager.ItemsManagerName };

        #endregion


        #region Methods

        public static void BuildItemsPool()
        {
            BuildFarmResourcesDictionary();
            BuildFarm();
        }

        private static void BuildFarm()
        {
            var farmDataArray = GameResourcesPresenter.FarmDataArray;

            foreach (var data in farmDataArray)
            {
                Farm newFarm = new Farm(data);
                Farms.Add(data.FarmType, newFarm);
            }
        }

        private static void BuildFarmResourcesDictionary()
        {
            var farmResourceDataArray = GameResourcesPresenter.FarmResourceDataArray;

            foreach (var data in farmResourceDataArray)
            {

                if (data.LoadFromJSON)
                {
                    FarmResource newFarmRes;
                    var newFarmResData = SaveDataController.FarmResourceLoad(data.JsonDataPath);
                    if (newFarmResData != null)
                    {
                        newFarmResData.Image = data.Image;
                        newFarmRes = new FarmResource(newFarmResData);
                    }
                    else
                        newFarmRes = new FarmResource(data);
                    FarmResources.Add(data.ResourceType, newFarmRes);
                }
                else
                {
                    SaveDataController.FarmResourceSave(data, true);
                    var newFarmRes = new FarmResource(data);
                    FarmResources.Add(data.ResourceType, newFarmRes);
                }


            }
        }

        //public static GameObject GetFarm(FarmType farmType)
        //{
        //    var farmPrefub = GameResourcesPresenter.FarmPrefub;

        //    foreach (var farm in Farms)
        //    {
        //        if (farmType == farm.Key)
        //        {
        //            var newGameObject = Instantiate(farmPrefub, SceneManager.FarmItemsParent) as GameObject;
        //            var newFarm = newGameObject.GetComponent<Farm>();
        //            Debug.Log(farm.Value.BuyPrice);
        //            newFarm.SetFarm(farm.Value); // не работает, кажется TODO
        //            var newFarmImage = newGameObject.GetComponentInChildren<Image>();
        //            newFarmImage.sprite = farm.Value.Image;
        //            return newGameObject;
        //        }
        //    }
        //    return null;
        //}

        #endregion
    }
}