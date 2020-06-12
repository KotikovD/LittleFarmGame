using System.Collections.Generic;
using LittleFarmGame.Controllers;
using UnityEngine;


namespace LittleFarmGame.Models
{
    /// <summary>
    /// Build all items (Farm and FramResource) and keep references
    /// </summary>
    public class ItemsManager : MonoBehaviour
    {


        #region Fileds

        public Dictionary<ResourceType, FarmResource> FarmResources;
        public Dictionary<FarmType, Farm> Farms;

        #endregion


        #region Methods

        public void BuildItemsPools()
        {
            FarmResources = new Dictionary<ResourceType, FarmResource>();
            Farms = new Dictionary<FarmType, Farm>();

            BuildFarmResources();
            BuildFarms();
        }

        private void BuildFarms()
        {
            var farmDataArray = GameResourcesPresenter.FarmDataArray;

            foreach (var data in farmDataArray)
            {
                if (data.LoadFromJSON)
                {
                    Farm newFarm;
                    var newFarmData = ServiceLocator.Resolve<SaveDataController>().FarmLoad(data.JsonDataPath);
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

        private void BuildFarmResources()
        {
            var farmResourceDataArray = GameResourcesPresenter.FarmResourceDataArray;

            foreach (var data in farmResourceDataArray)
            {

                if (data.LoadFromJSON)
                {
                    FarmResource newFarmRes;
                    var newFarmResData = ServiceLocator.Resolve<SaveDataController>().FarmResourceLoad(data.JsonDataPath);
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