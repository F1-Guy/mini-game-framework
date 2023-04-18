namespace minigame_library.Items
{
    public class AttackItem : Item
    {
        public AttackItem(int id, string name, int damage, int ranage, string? description = null) :
            base(id, name, description)
        {
            Damage = damage;
            Range = ranage;
        }

        /// <summary>
        /// Specifies the amount of damage the item will deal
        /// </summary>
        public int Damage { get; set; }

        /// <summary>
        /// Specifies the range of the item
        /// </summary>
        public int Range { get; set; }
    }
}
