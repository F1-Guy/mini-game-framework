using minigame_library.World;

namespace minigame_library.Objects
{
    public class Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Position(Position position)
        {
            X = position.X;
            Y = position.Y;
        }

        /// <summary>
        /// Gets or sets the X coordinate of the position
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the Y coordinate of the position
        /// </summary>
        public int Y { get; set; }

        #region Operator overloads
        public static bool operator ==(Position position1, Position position2)
        {
            return position1.X == position2.X && position1.Y == position2.Y;
        }

        public static bool operator !=(Position position1, Position position2)
        {
            return position1.X != position2.X || position1.Y != position2.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
        #endregion

        #region Distance methods
        /// <summary>
        /// Calculates the shortest distance between the current position and the given position
        /// </summary>
        /// <param name="position"></param>
        /// <returns>The distance between the current position and <paramref name="position"/></returns>
        public double DistanceFromCurrentPosition(Position position)
        {
            return Math.Sqrt(Math.Pow(position.X - X, 2) + Math.Pow(position.Y - Y, 2));
        }

        /// <summary>
        /// Calculates the shortest distance between two positions on the map
        /// </summary>
        /// <param name="position1"></param>
        /// <param name="position2"></param>
        /// <returns>The distance between <paramref name="position1"/> and <paramref name="position2"/></returns>        
        public static double DistanceBetweenPositions(Position position1, Position position2)
        {
            return Math.Sqrt(Math.Pow(position1.X - position2.X, 2) + Math.Pow(position1.Y - position2.Y, 2));
        }
        #endregion

        /// <summary>
        /// Determines if <paramref name="position"/> is out of bounds
        /// </summary>
        /// <param name="position"></param>
        /// <returns>The boolean that determines if the position is out of bounds</returns>
        public bool IsOutOfBounds()
        {
            var map = Map.GetInstance();
            return Math.Abs(X) > map.MaxX || Math.Abs(Y) > map.MaxY;
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }
    }
}