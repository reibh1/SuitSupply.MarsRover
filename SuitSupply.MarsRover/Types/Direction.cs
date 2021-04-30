namespace SuitSupply.MarsRover.Types
{
    public enum Direction
    {
        North,
        East,
        South,
        West
    }

    public static class DirectionExtensions 
    {
        public static Direction RotateRight(this Direction direction)
        {
            return (Direction)(((int)direction + 1) % 4);
        }

        public static Direction RotateLeft(this Direction direction)
        {
            var newDirection = (int)direction - 1;
            return (Direction)(newDirection < 0 ? 3 : newDirection);
        }

        public static bool IsVertical(this Direction value) => value == Direction.North || value == Direction.South;

        public static bool IsReversed(this Direction value) => value == Direction.North || value == Direction.West;
    }
}
