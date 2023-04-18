using minigame_library.Objects;

namespace minigame_library.World
{
    public class Map
    {
        private static Map? _instance;
        private List<Entity> _entities;
        private static Logger _logger = Logger.GetInstance();
        private static int _id = 0;

        private Map()
        {
            throw new InvalidOperationException("Use the Map.CreateInstance() method instead.");
        }

        private Map(int maxX, int maxY, List<Entity>? entities = null)
        {
            MaxX = maxX;
            MaxY = maxY;
            _entities = entities ?? new List<Entity>();
        }

        public int MaxX { get; }

        public int MaxY { get; }

        // Make this private and add methods to modify the list
        public List<Entity> Entities { get { return _entities; } }

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

        private bool IsOutOfBounds(Position position)
        {
            if (Math.Abs(position.X) > MaxX || Math.Abs(position.Y) > MaxY) return true;

            return false;
        }

        #region Entity Methods
        public Entity AddEntity(Entity entity)
        {
            if (IsOutOfBounds(entity.Position)) throw new InvalidDataException($"Position: {entity.Position.ToString()} is out of map bounds");
            entity.Id = _id++;

            _entities.Add(entity);

            return entity;
        }

        public void RemoveEntity(Entity entity)
        {
            _entities.Remove(_entities.Find(e => e.Id == entity.Id) ?? throw new Exception("Entity was not found"));
        }

        public void RemoveEntity(int id)
        {
            _entities.Remove(_entities.Find(e => e.Id == id) ?? throw new Exception("Entity was not found"));
        }

        public void RemoveEnitiesAtPosition(Position position)
        {
            foreach (Entity entity in _entities)
            {
                if (entity.Position == position)
                {
                    _entities.Remove(entity);
                }
            }
        }
        #endregion

        public override string ToString()
        {
            return $"maximum x: {MaxX} maximum y: {MaxY}";
        }
    }
}
