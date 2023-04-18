using minigame_library.Objects;

namespace minigame_library.World
{
    public class Map
    {
        private static Map? _instance;
        private static readonly Logger _logger = Logger.GetInstance();
        private static int _id = 0;

        private Map()
        {
            throw new InvalidOperationException("Use the Map.CreateInstance() method instead.");
        }

        private Map(int maxX, int maxY, List<Entity>? entities = null)
        {
            MaxX = maxX;
            MaxY = maxY;
            Entities = entities ?? new List<Entity>();
        }

        /// <summary>
        /// Gets the maximum X (positive and negative) value of the map
        /// </summary>
        public int MaxX { get; }

        /// <summary>
        /// Gets the maximum Y (positive and negative) value of the map
        /// </summary>
        public int MaxY { get; }

        public List<Entity> Entities { get; }

        #region Singleton Methods
        public static Map CreateInstance(int maxX, int maxY, List<Entity>? entities = null)
        {
            if (_instance != null)
            {
                _logger.Log(TraceEventType.Error, $"Map object already created");
                throw new InvalidOperationException("Object already created");
            }

            _instance = new Map(maxX, maxY, entities);
            _logger.Log(TraceEventType.Information, $"Map created with max-x: {maxX} max-y: {maxY}");
            return _instance;
        }

        public static Map GetInstance()
        {
            if (_instance == null)
            {
                _logger.Log(TraceEventType.Error, $"Map object does not exist");
                throw new InvalidOperationException("Object not created");
            }

            _logger.Log(TraceEventType.Verbose, "Map instance accessed");
            return _instance;
        }
        #endregion

        #region Entity Methods
        /// <summary>
        /// Add <paramref name="entity"/> to the map
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>The reference to <paramref name="entity"/></returns>
        /// <exception cref="InvalidDataException"></exception>
        public Entity AddEntity(Entity entity)
        {
            if (IsOutOfBounds(entity.Position)) throw new InvalidDataException($"Position: {entity.Position} is out of map bounds");
            entity.Id = _id++;

            Entities.Add(entity);

            return entity;
        }

        /// <summary>
        /// Remove <paramref name="entity"/> from the map by reference
        /// </summary>
        /// <param name="entity"></param>
        public void RemoveEntity(Entity entity)
        {
            Entities.Remove(entity);
        }

        /// <summary>
        /// Remove all entities with the <paramref name="id"/> from the map
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void RemoveEntities(int id)
        {
            Entities.Remove(Entities.Find(e => e.Id == id) ?? throw new InvalidOperationException("Entity was not found"));
        }

        /// <summary>
        /// Remove all entities with the <paramref name="name"/> from the map
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void RemoveEntities(string name)
        {
            Entities.Remove(Entities.Find(e => e.Name == name) ?? throw new InvalidOperationException("Entity was not found"));
        }

        /// <summary>
        /// Remove all entities at <paramref name="position"/> from the map
        /// </summary>
        /// <param name="position"></param>
        public void RemoveEnities(Position position)
        {
            foreach (Entity entity in Entities)
            {
                if (entity.Position == position)
                {
                    Entities.Remove(entity);
                }
            }
        }

        /// <summary>
        /// Determines if <paramref name="position"/> is out of bounds
        /// </summary>
        /// <param name="position"></param>
        /// <returns>The boolen that determines if the position is out of bounds</returns>
        public bool IsOutOfBounds(Position position)
        {
            return Math.Abs(position.X) > MaxX || Math.Abs(position.Y) > MaxY;
        }
        #endregion

        public override string ToString()
        {
            return $"maximum x: {MaxX} maximum y: {MaxY}";
        }
    }
}
