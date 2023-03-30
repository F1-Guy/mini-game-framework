using minigame_library.Objects;

namespace minigame_library.World
{
    public class Map
    {
        private static Map _instance;

        private Map() { }

        private Map(int maxX, int maxY, List<Entity>? entities = null)
        {
            MaxX = maxX;
            MaxY = maxY;
            Entities = entities ?? new List<Entity>();
        }

        public int MaxX { get; set; }

        public int MaxY { get; set; }

        public List<Entity> Entities { get; set; }

        public static Map GetInstance()
        {
            if (_instance == null)
            {
                throw new InvalidOperationException("Object not created");
            }
            return _instance;
        }

        public static Map CreateInstance(int maxX, int maxY, List<Entity>? entities = null)
        {
            if (_instance != null)
            {
                throw new InvalidOperationException("Object already created");
            }

            _instance = new Map(maxX, maxY, entities);
            return _instance;
        }   
    }
}
