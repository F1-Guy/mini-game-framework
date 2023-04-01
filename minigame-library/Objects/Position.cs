namespace minigame_library.Objects
{
    public class Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public double DistanceFromCurrentPosition(Position position)
        {
            return Math.Sqrt(Math.Pow(position.X - X, 2) + Math.Pow(position.Y - Y, 2));
        }

        public static double DistanceBetweenPositions(Position position1, Position position2)
        {
            return Math.Sqrt(Math.Pow(position1.X - position2.X, 2) + Math.Pow(position1.Y - position2.Y, 2));
        }
    }
}