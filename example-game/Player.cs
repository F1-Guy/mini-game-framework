using minigame_library.Items;
using minigame_library.Logging;
using minigame_library.Objects;
using System.Diagnostics;

namespace example_game
{
    public class Player : Creature
    {
        Logger _logger = Logger.GetInstance();

        public Player(string name, Position startPosition, int speed, int startHealth = 100, List<Item>? startInventory = null)
            : base(name, startPosition, startHealth, startInventory)
        {
            Speed = speed;
        }

        int Speed;

        public void Heal(int health)
        {
            Health += health;
        }

        public override void Move(Direction direction)
        {
            Position newPosition = new(Position);

            switch (direction)
            {
                case Direction.North:
                    newPosition.Y += Speed;
                    break;
                case Direction.South:
                    newPosition.Y -= Speed;
                    break;
                case Direction.East:
                    newPosition.X += Speed;
                    break;
                case Direction.West:
                    newPosition.X -= Speed;
                    break;
            }

            if (newPosition.IsOutOfBounds())
            {
                _logger.Log(TraceEventType.Warning, $"Entity {Name} tried to move out of bounds from {Position} to {newPosition}");
                return;
            }

            Position = new(newPosition);
        }
    }
}
