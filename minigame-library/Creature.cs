namespace minigame_library
{
    public class Creature
    {
        public Position Position { get; set; }

        public int Hitpoint { get; set; }

        public string? Name { get; set; }

        public List<AttackItem> AttackItems { get; set; }

        public List<DefenceItem> DefenceItems { get; set; }

        public void Hit()
        {
            throw new NotImplementedException();
        }

        public void Loot()
        {
            throw new NotImplementedException();
        }

        public void ReceiveHit()
        {
            throw new NotImplementedException();
        }
    }
}
