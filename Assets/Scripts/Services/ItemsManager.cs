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
                if (data.LoadFromJSON)
                {
                    Farm newFarm;
                    var newFarmData = SaveDataController.FarmLoad(data.JsonDataPath);
                    if (newFarmData != null)
                    {
                        newFarmData.Image = data.Image;
                        newFarm = new Farm(newFarmData);
                    }
                    else
                        newFarm = new Farm(data);
                    Farms.Add(data.FarmType, newFarm);
                }
                else
                {
                    var newFarm = new Farm(data);
                    Farms.Add(data.FarmType, newFarm);
                }
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
                    var newFarmRes = new FarmResource(data);
                    FarmResources.Add(data.ResourceType, newFarmRes);
                }
            }
        }

        #endregion


    }
}