using minigame_library.Items;
using minigame_library.World;

namespace minigame_library.Objects
{
    public class Creature : Entity
    {
        public Creature(string name, Position startPosition, int unarmedDamage, int startHealth = 100, List<Item>? startInventory = null) :
            base(name, startPosition, startHealth, startInventory)
        {
            UnarmedDamage = unarmedDamage;
        }

        public int UnarmedDamage { get; set; }

        // Need to add range checking for the attack items
        public void Hit(Entity entity, AttackItem? attackItem = null)
        {
            if (entity.IsDead) return;

            if (attackItem != null)
            {
                entity.ReceiveHit(attackItem.Damage);
                return;
            }

            entity.ReceiveHit(UnarmedDamage);
        }

        public void Hit(Position position, AttackItem? attackItem = null)
        {
            var map = Map.GetInstance();

            foreach (var entity in map.Entities.Where(e => e.Position == position))
            {
                if (attackItem != null)
                {
                    entity.ReceiveHit(attackItem.Damage);
                }
                else
                {
                    entity.ReceiveHit(UnarmedDamage);
                }
            }
        }

        public override void ReceiveHit(int damage)
        {
            if (!IsDead) Health -= damage;
        }

        public void Loot(WorldObject @object)
        {
            if (@object.IsLootable) Inventory.AddRange(@object.Inventory);
        }

        public void Pick(Creature creature)
        {
            if (creature.IsDead) Inventory.AddRange(creature.Inventory);
        }
    }
}
