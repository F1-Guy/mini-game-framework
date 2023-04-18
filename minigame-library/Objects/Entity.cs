using minigame_library.Items;

namespace minigame_library.Objects
{
    public abstract class Entity
    {
        private readonly Logger _logger = Logger.GetInstance();

        public Entity(string name, Position startPosition, int startHealth, List<Item>? startInventory)
        {
            Name = name;
            Position = startPosition;
            Health = startHealth;
            Inventory = startInventory ?? new List<Item>();
            _logger.Log(TraceEventType.Information, $"Entity was created at position {startPosition} Name: {name}");
        }

        /// <summary>
        /// Gets or sets ID of the entity. ID is NOT unique
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the entity
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the health of the entity
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// Gets default unarmed attack item for all entities
        /// </summary>
        public AttackItem Unarmed { get; } = new AttackItem(0, "Unarmed", 10, 1);

        /// <summary>
        /// Gets boolean based on the health of the entity
        /// </summary>
        public bool IsDead => Health <= 0;

        /// <summary>
        /// Gets or Sets position of the entity
        /// </summary>
        public Position Position { get; set; }

        /// <summary>
        /// Gets or sets the inventory of the entity
        /// </summary>
        public List<Item> Inventory { get; set; }

        /// <summary>
        /// Every entity can receive damage
        /// </summary>
        /// <param name="damage"></param>
        public abstract void ReceiveHit(int damage);
    }
}
