using minigame_library.Items;

namespace minigame_library.Objects
{
    public class WorldObject : Entity
    {
        public WorldObject(string name, Position position, bool isLootable, bool isRemovable, int startHealth = 100, List<Item>? startInventory = null)
            : base(name, position, startHealth, startInventory)
        {
            IsLootable = isLootable;
            IsRemovable = isRemovable;
        }

        public bool IsLootable { get; set; }

        public bool IsRemovable { get; set; }

        public override void ReceiveHit(int damage)
        {
            if (IsRemovable) Health -= damage;
        }
    }
}
