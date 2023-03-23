using minigame_library.Items;

namespace minigame_library.Objects
{
    public class WorldObject : Entity
    {
        public WorldObject(int id, string name, int startHealth, Position startPosition, List<Item> startInventory, bool isLootable, bool isRemovable)
            : base(id, name, startPosition, startHealth, startInventory)
        {
            IsLootable = isLootable;
            IsRemovable = isRemovable;
        }

        public bool IsLootable { get; set; }

        public bool IsRemovable { get; set; }
    }
}
