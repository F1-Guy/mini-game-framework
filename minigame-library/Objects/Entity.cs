using minigame_library.Items;

namespace minigame_library.Objects
{
    public abstract class Entity
    {
        Logger _logger = Logger.GetInstance();

        public Entity(string name, Position startPosition, int startHealth, List<Item>? startInventory)
        {
            Name = name;
            Position = startPosition;
            Health = startHealth;
            Inventory = startInventory ?? new List<Item>();
            _logger.Log(TraceEventType.Information, $"Entity of type was created at position {startPosition}");
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
