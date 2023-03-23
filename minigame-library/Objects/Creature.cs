using minigame_library.Items;

namespace minigame_library.Objects
{
    public class Creature : Entity
    {
        public Creature(int id, string name, int startHealth, Position startPosition, List<Item> startInventory) :
            base(id, name, startPosition, startHealth, startInventory)
        {

        }

        public void Hit()
        {
            throw new NotImplementedException();
        }

        public void Loot()
        {
            throw new NotImplementedException();
        }
    }
}
