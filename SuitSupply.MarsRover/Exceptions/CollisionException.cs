using System;
using SuitSupply.MarsRover.Types;

namespace SuitSupply.MarsRover.Exceptions
{
    public class CollisionException : Exception
    {
        public CollisionException(Position lastPosition) :
            base($"({lastPosition.Coordinate.X}, {lastPosition.Coordinate.Y}) {lastPosition.Direction} Stopped.")
        {
            LastPosition = lastPosition;
        }

        public Position LastPosition { get; }
    }
}