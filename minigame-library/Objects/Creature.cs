using minigame_library.Items;
using minigame_library.World;

namespace minigame_library.Objects
{
    public class Creature : Entity
    {
        private readonly DefenceItem unarmored = new(0, "Unarmored", 0, "Used when no armor is equipped. Does not offer any protection");

        public Creature(string name, Position startPosition, int startHealth = 100, List<Item>? startInventory = null) :
            base(name, startPosition, startHealth, startInventory)
        {
            Unarmed = new AttackItem(0, "Unarmed", 10, 1);
            DefenceItem = unarmored;
        }

        /// <summary>
        /// Gets default unarmed attack item for all entities
        /// </summary>
        public AttackItem Unarmed { get; }

        /// <summary>
        /// Currently equipped defense item
        /// </summary>
        private DefenceItem DefenceItem;

        /// <summary>
        /// Moves Creature in <paramref name="direction"/> by 1 unit
        /// </summary>
        /// <param name="direction"></param>
        public void Move(Direction direction)
        {
            Position newPosition = new(Position);

            switch (direction)
            {
                case Direction.North:
                    newPosition.Y++;
                    break;
                case Direction.South:
                    newPosition.Y--;
                    break;
                case Direction.East:
                    newPosition.X++;
                    break;
                case Direction.West:
                    newPosition.X--;
                    break;
            }

            if (newPosition.IsOutOfBounds()) return;

            Position = new(newPosition);
        }

        /// <summary>
        /// Deal damage to a specific entity if the entity is in range of the attack item
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="attackItem"></param>
        public void Hit(Entity entity, AttackItem? attackItem = null)
        {
            attackItem ??= Unarmed;

            if (!Inventory.Contains(attackItem)) return;
            if (attackItem.Range < Position.DistanceFromCurrentPosition(entity.Position)) return;

            var damage = attackItem.Damage - DefenceItem.Protection;
            if (damage < 0) damage = 0;

            entity.ReceiveHit(damage);
        }


        /// <summary>
        /// Deal damage to all entities that are in the specified position and in range of the attack item
        /// </summary>
        /// <param name="position"></param>
        /// <param name="attackItem"></param>
        public void Hit(Position position, AttackItem? attackItem = null)
        {
            attackItem ??= Unarmed;

            if (!Inventory.Contains(attackItem)) return;

            Map map = Map.GetInstance();

            if (attackItem.Range < Position.DistanceFromCurrentPosition(position)) return;

            foreach (Entity? entity in map.Entities.Where(e => e.Position == position))
            {
                var damage = attackItem.Damage - DefenceItem.Protection;

                if (damage < 0) damage = 0;

                entity.ReceiveHit(attackItem.Damage);
            }
        }

        /// <summary>
        /// Receive damage from attack and reduce health if not dead
        /// </summary>
        /// <param name="damage"></param>
        public override void ReceiveHit(int damage)
        {
            if (!IsDead) Health -= damage;
        }

        /// <summary>
        /// Take all items from object and add them to inventory if the object is lootable and in range
        /// </summary>
        /// <param name="object"></param>
        public void Loot(WorldObject @object)
        {
            if (Unarmed.Range < Position.DistanceFromCurrentPosition(@object.Position)) return;

            if (@object.IsLootable) Inventory.AddRange(@object.Inventory);
        }

        /// <summary>
        /// Take all items from creature and add them to inventory if the creature is dead and in range
        /// </summary>
        /// <param name="creature"></param>
        public void Pick(Creature creature)
        {
            if (Unarmed.Range < Position.DistanceFromCurrentPosition(creature.Position)) return;

            if (creature.IsDead) Inventory.AddRange(creature.Inventory);
        }

        /// <summary>
        /// Equips a specific defense item if it is in the inventory
        /// </summary>
        /// <param name="defenceItem"></param>
        public void Equip(DefenceItem defenceItem)
        {
            if (Inventory.Contains(defenceItem))
            {
                DefenceItem = defenceItem;
            }
        }

        /// <summary>
        /// Removes the currently equipped defense item and equips the default unarmored item
        /// </summary>
        public void UnEquip()
        {
            DefenceItem = unarmored;
        }
    }
}