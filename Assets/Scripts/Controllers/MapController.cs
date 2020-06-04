using System.Collections.Generic;
using LittleFarmGame.Models;


namespace LittleFarmGame.Controllers
{
    public sealed class MapController : IInitialization
    {

        public void Initialization()
        {

            List<FarmCell> _farmCells = new List<FarmCell>();

            for (int i = 0; i < 5; i++)
            {
               _farmCells.Add(new FarmCell(false, true, i, i));
            }
            _farmCells.Add(new FarmCell(false, true, 0, 5));
            _farmCells.Add(new FarmCell(false, false, 1, 2));
            _farmCells.Add(new FarmCell(false, false, 1, 3));

            SceneObjectPresenter.Map.FillMap(_farmCells);
        }
    }
}