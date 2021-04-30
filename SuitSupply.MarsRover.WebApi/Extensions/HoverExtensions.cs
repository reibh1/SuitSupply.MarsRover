using Direction = SuitSupply.MarsRover.Types.Direction;
using PositionStruct = SuitSupply.MarsRover.Types.Position;
using System;
using SuitSupply.MarsRover.WebApi.Model;

namespace SuitSupply.MarsRover.WebApi.Extensions
{
    public static class HoverExtensions
    {
        public static Position ToPositionModel(this PositionStruct position)
        {
            return new Position
            {
                Coordinate = new Coordinate(position.Coordinate.X, position.Coordinate.Y),
                DirectionEnum = position.Direction
            };
        }

        public static Direction ToDirection(this string direction)
        {
            Enum.TryParse(typeof(Direction), direction, ignoreCase: true, out var directionEnum);

            return (Direction)(directionEnum ?? Direction.North);
        }
    }
}