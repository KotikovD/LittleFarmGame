using LittleFarmGame.Models;


namespace LittleFarmGame.Controllers
{
    public class PlayerInventoryJSON
    {
        public ResourceType ResourceType;
        public int Count;


        public PlayerInventoryJSON(ResourceType resourceType, int count)
        {
            ResourceType = resourceType;
            Count = count;
        }

    }
}