using System.Collections.Generic;
using LittleFarmGame.Models;


namespace LittleFarmGame.Controllers
{
    /// <summary>
    /// Game level generation data hard code
    /// </summary>
    internal class WebGLNewGame
    {

        public int GetGameCoinsData()
        {
            var coins = 300;
            return coins;
        }

        public Dictionary<ResourceType, int> GetGameInventoryData()
        {
            var inventoryData = new Dictionary<ResourceType, int>();
            inventoryData.Add(ResourceType.Wheat, 5);

            return inventoryData;
        }

        public Dictionary<int, FarmCell> GetGameFarmCellsData()
        {
            var farmCellsData = new Dictionary<int, FarmCell>();

            for (int x = 0; x <= 7; x++)
            {
                for (int z = 0; z <= 7; z++)
                {
                    if (x == 0 || z == 0 || x == 7 || z == 7)
                        farmCellsData.Add(farmCellsData.Count,
                            new FarmCell(
                            farmCellsData.Count,
                            false,
                            false,
                            x,
                            z,
                            FarmType.None,
                            50));
                    else if (x == 1 || z == 1 || x == 6 || z == 6)
                        farmCellsData.Add(farmCellsData.Count,
                            new FarmCell(
                            farmCellsData.Count,
                            false,
                            false,
                            x,
                            z,
                            FarmType.None,
                            25));
                    else
                         farmCellsData.Add(farmCellsData.Count,
                            new FarmCell(
                            farmCellsData.Count,
                            false,
                            true,
                            x,
                            z,
                            FarmType.None,
                            25));
                }
            }

            return farmCellsData;
        }



    }
}