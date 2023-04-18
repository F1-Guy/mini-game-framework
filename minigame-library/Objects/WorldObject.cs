using minigame_library.Items;
using minigame_library.World;

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

        /// <summary>
        /// Gets or sets a value indicating whether the object can be looted
        /// </summary>
        public bool IsLootable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the object can be removed
        /// </summary>
        public bool IsRemovable { get; set; }

        /// <summary>
        /// If the object is removable, it can receive damage and be destroyed
        /// </summary>
        /// <param name="damage"></param>
        public override void ReceiveHit(int damage)
        {
            if (IsRemovable) Health -= damage;
            if (IsDead) Map.GetInstance().RemoveEntity(this);
        }
    }
}
