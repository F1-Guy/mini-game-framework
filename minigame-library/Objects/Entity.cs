using minigame_library.Items;

namespace minigame_library.Objects
{
    public abstract class Entity
    {
        public Entity(int id, string name, Position startPosition, int startHealth, List<Item>? startInventory)
        {
            Id = id;
            Name = name;
            Position = startPosition;
            Health = startHealth;
            Inventory = startInventory ?? new List<Item>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Health { get; set; }

        public bool IsDead => Health <= 0;

        public Position Position { get; set; }

        public List<Item> Inventory { get; set; }

        public abstract void ReceiveHit(int damage);
    }
}
