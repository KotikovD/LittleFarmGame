using UnityEngine;


namespace LittleFarmGame.Models
{
    public static class ResourcesObjectPresenter
    {
        public static FarmCell CellPrefub;
        public static GameObject FarmResourcePrefub;
        public static GameObject FarmPrefub;
        public static FarmResourceData[] FarmResourceDataArray;
        public static FarmData[] FarmDataArray;

        public static void InitializeResources()
        {
            CellPrefub = Resources.Load<FarmCell>(StringManager.FarmCellPath);
            FarmResourcePrefub = Resources.Load<GameObject>(StringManager.FarmResourcePath);
            FarmResourceDataArray = Resources.LoadAll<FarmResourceData>(StringManager.FarmResourceDataPath);
            FarmPrefub = Resources.Load<GameObject>(StringManager.FarmPath);
            FarmDataArray = Resources.LoadAll<FarmData>(StringManager.FarmDataPath);
        }
        
    }
}