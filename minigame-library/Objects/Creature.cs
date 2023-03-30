using minigame_library.Items;
using minigame_library.World;

namespace minigame_library.Objects
{
    public class Creature : Entity
    {
        public Creature(int id, string name, Position startPosition, int unarmedDamage, int startHealth = 100, List<Item>? startInventory = null) :
            base(id, name, startPosition, startHealth, startInventory)
        {
            UnarmedDamage = unarmedDamage;
        }

        public int UnarmedDamage { get; set; }

        // Need to add range checking for the attack items
        public void Hit(Entity entity, AttackItem? attackItem = null)
        {
            if (attackItem != null)
            {
                entity.ReceiveHit(attackItem.Damage);
                return;
            }

            entity.ReceiveHit(UnarmedDamage);
        }

        public void Hit(Position position, AttackItem? attackItem = null) 
        {
            if (attackItem != null)
            {
                var map = Map.GetInstance();

                foreach (var entity in map.Entities.Where(e => e.Position == position))
                {
                    entity.ReceiveHit(attackItem.Damage);
                }
            }
        }

        public void Loot()
        {
            throw new NotImplementedException();
        }

        public override void ReceiveHit(int damage)
        {
            throw new NotImplementedException();
        }
    }
}
