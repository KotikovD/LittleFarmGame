using System.Collections.Generic;
using LittleFarmGame.Models;


namespace LittleFarmGame.Controllers
{
    public sealed class MapController : IInitialization
    {

        public void Initialization()
        {
            // for tests TODO get info from json
            List<FarmCell> _farmCells = new List<FarmCell>();
            var cellBuyPrice = 25;
            for (int x = 0; x <= 7; x++)
            {
                for (int z = 0; z <= 7; z++)
                {
                    FarmCell fc;


                    if (x <= 1 || z <= 1 || x >= 6 || z >= 6)
                    {
                        if (x == 0 || z == 0 || x == 7 || z == 7)
                            fc = new FarmCell(false, false, x, z, FarmType.None, cellBuyPrice * 2);
                        else
                            fc = new FarmCell(false, false, x, z, FarmType.None, cellBuyPrice);
                    }
                    else
                    {
                        fc = new FarmCell(false, true, x, z, FarmType.None, cellBuyPrice);
                    }

                    _farmCells.Add(fc);


                }

            }




            SceneManager.Map.FillMap(_farmCells);
        }
    }
}