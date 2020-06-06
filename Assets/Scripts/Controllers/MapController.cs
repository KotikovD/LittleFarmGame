using System.Collections.Generic;
using LittleFarmGame.Models;


namespace LittleFarmGame.Controllers
{
    public sealed class MapController : IInitialization
    {

        public void Initialization()
        {

            List<FarmCell> _farmCells = new List<FarmCell>();

            // for tests
            for (int x = 0; x <= 9; x++)
            {
                for (int z = 0; z <= 9; z++)
                {
                    var fc = new FarmCell();
                    if (x == 5 && z == 5)
                    {
                        fc = new FarmCell();
                        fc.SetFarmCell(false, true, x, z, FarmType.Cow);
                        _farmCells.Add(fc);
                        continue;
                    }

                    if (x <= 1 || z <= 1 || x >= 8 || z >= 8)
                    {
                        fc = new FarmCell();
                        fc.SetFarmCell(false, true, x, z, FarmType.None);
                    }
                    else
                    {
                        
                        fc.SetFarmCell(false, true, x, z, FarmType.None);
                    }
                        _farmCells.Add(fc);

                    
                }

            }




            SceneObjectPresenter.Map.FillMap(_farmCells);
        }
    }
}