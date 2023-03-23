using minigame_library.Items;

namespace minigame_library.Objects
{
    public abstract class Entity
    {
        public Entity(int id, string name, Position startPosition, int startHealth = 100, List<Item>? startInventory = null)
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

        public Position Position { get; set; }

        public List<Item> Inventory { get; set; }

        virtual public void ReceiveHit()
        {
            throw new NotImplementedException();
        }
    }
}
