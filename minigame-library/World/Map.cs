using minigame_library.Objects;

namespace minigame_library.World
{
    public class Map
    {
        public Map(int maxX, int maxY, List<Entity>? entities = null)
        {
            MaxX = maxX;
            MaxY = maxY;
            Entities = entities ?? new List<Entity>();
        }

        public int MaxX { get; set; }

        public int MaxY { get; set; }

        public List<Entity> Entities { get; set; }
    }
}
