namespace minigame_library.Items
{
    public class AttackItem : Item
    {
        public AttackItem(int id, string name, int damage, int ranage, string? description = null):
            base(id, name, description)
        {
            Damage = damage;
            Range = ranage;
        }

        public int Damage { get; set; }

        public int Range { get; set; }
    }
}
