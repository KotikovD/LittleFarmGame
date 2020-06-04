using UnityEngine;


namespace LittleFarmGame.Models
{
    public static class ResourcesObjectPresenter
    {
        public static FarmCell CellPrefub;

        public static void InitializeResources()
        {
            CellPrefub = Resources.Load<FarmCell>(StringManager.FarmCellPath);
        }

    }
}