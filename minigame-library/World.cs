namespace minigame_library
{
    public class World
    {
        public int MaxX { get; set; }

        public int MaxY { get; set; }

        public List<WorldObject> WorldObjects { get; set; }

        public List<Creature> Creatures { get; set; }
    }
}
