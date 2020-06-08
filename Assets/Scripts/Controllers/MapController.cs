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

            for (int x = 0; x <= 7; x++)
            {
                for (int z = 0; z <= 7; z++)
                {
                    FarmCell fc;

                    if (x == 2  && z == 2)
                    {
                        fc = new FarmCell(false, true, x, z, FarmType.Cow);
                    }
                    else if (x == 2 && z == 5)
                    {
                        fc = new FarmCell(false, true, x, z, FarmType.Chicken);
                    }
                    else if (x == 4 && z == 4)
                    {
                        fc = new FarmCell(false, true, x, z, FarmType.Wheat);
                    }
                    else if (x <= 1 || z <= 1 || x >= 6 || z >= 6)
                    {
                        fc = new FarmCell(false, false, x, z, FarmType.None);
                    }
                    else
                    {
                        fc = new FarmCell(false, true, x, z, FarmType.None);
                    }

                    _farmCells.Add(fc);

                    
                }

            }




            SceneManager.Map.FillMap(_farmCells);
        }
    }
}