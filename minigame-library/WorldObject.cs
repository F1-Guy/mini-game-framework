namespace minigame_library
{
    public class WorldObject
    {
        public Position Position { get; set; }

        public string? Name { get; set; }

        public bool isLootable { get; set; }

        public bool isRemovable { get; set; }

        public List<AttackItem> AttackItems { get; set; }

        public List<DefenceItem> DefenceItems { get; set; }
    }
}
