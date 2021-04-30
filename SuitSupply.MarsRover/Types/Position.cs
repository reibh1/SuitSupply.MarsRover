namespace SuitSupply.MarsRover.Types
{
    public struct Position
    {
        public Coordinate Coordinate;
        public Direction Direction;
    }

    public static class PositionExtensions 
    {
        public static Coordinate MoveForward(this Position position)
        {
            return Move(position, forward: true);
        }

        public static Coordinate MoveBackward(this Position position)
        {
            return Move(position, forward: false);
        }

        private static Coordinate Move(Position position, bool forward)
        {
            int invert = position.Direction.IsReversed() ^ !forward ? - 1 : 1;

            return new Coordinate
            {
                X = position.Coordinate.X + (!position.Direction.IsVertical() ? 1 * invert : 0),
                Y = position.Coordinate.Y + (position.Direction.IsVertical() ? 1 * invert: 0)
            };

        }
    }
}
