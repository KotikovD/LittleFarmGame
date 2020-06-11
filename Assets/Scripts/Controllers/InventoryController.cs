using System.Collections.Generic;
using LittleFarmGame.Models;


namespace LittleFarmGame.Controllers
{
    public sealed class InventoryController : IInitialization
    {


        public void Initialization()
        {

            // for tests TODO get info from json

            Dictionary<ResourceType, int> InventoryData = new Dictionary<ResourceType, int>();

            InventoryData.Add(ResourceType.Wheat, 5);
            //InventoryData.Add(ResourceType.Egg, 5);
            //InventoryData.Add(ResourceType.Milk, 5);

            SceneManager.PlayerInventory.BuildInventory(InventoryData, 100);



        }
    }
}


