using NUnit.Framework;
using Shouldly;
using SuitSupply.MarsRover.Types;

namespace SuitSupply.MarsRover.Test
{
    public class PositionTests
    {
        [TestCase(5, 5, Direction.East, 6, 5)]
        [TestCase(10, 10, Direction.West, 9, 10)]
        [TestCase(0, 0, Direction.North, 0, -1)]
        [TestCase(-12, -12, Direction.South, -12, -11)]
        public void MoveForward_ShouldMoveProperly(int initialX,  int initialY, Direction direction, int finalX, int finalY)
        {
            // Arrange
            var sourcePosition = new Position {Coordinate = new Coordinate(initialX, initialY), Direction = direction};
            var expectedDestinationCoordinate = new Coordinate(finalX, finalY);

            // Act
            var destinationCoordinate = sourcePosition.MoveForward();

            // Assert
            destinationCoordinate.ShouldBe(expectedDestinationCoordinate);
        }

        [TestCase(5, 5, Direction.East, 4, 5)]
        [TestCase(10, 10, Direction.West, 11, 10)]
        [TestCase(0, 0, Direction.North, 0, 1)]
        [TestCase(-12, -12, Direction.South, -12, -13)]
        public void MoveBackward_ShouldMoveProperly(int initialX,  int initialY, Direction direction, int finalX, int finalY)
        {
            // Arrange
            var sourcePosition = new Position {Coordinate = new Coordinate(initialX, initialY), Direction = direction};
            var expectedDestinationCoordinate = new Coordinate(finalX, finalY);

            // Act
            var destinationCoordinate = sourcePosition.MoveBackward();

            // Assert
            destinationCoordinate.ShouldBe(expectedDestinationCoordinate);
        }

        [TestCase(5, 5, Direction.East, 5, 6)]
        [TestCase(10, 10, Direction.West, 10, 9)]
        [TestCase(0, 0, Direction.North, -1, 0)]
        [TestCase(-12, -12, Direction.South, -11, -12)]
        public void MoveForward_ShouldNotMatchWrongAxis(int initialX,  int initialY, Direction direction, int finalX, int finalY)
        {
            // Arrange
            var sourcePosition = new Position {Coordinate = new Coordinate(initialX, initialY), Direction = direction};
            var expectedDestinationCoordinate = new Coordinate(finalX, finalY);

            // Act
            var destinationCoordinate = sourcePosition.MoveForward();

            // Assert
            destinationCoordinate.ShouldNotBe(expectedDestinationCoordinate);
        }

        [TestCase(5, 5, Direction.East, 5, 4)]
        [TestCase(10, 10, Direction.West, 10, 11)]
        [TestCase(0, 0, Direction.North, 1, 0)]
        [TestCase(-12, -12, Direction.South, -13, -12)]
        public void MoveBackward_ShouldNotMatchWrongAxis(int initialX,  int initialY, Direction direction, int finalX, int finalY)
        {
            // Arrange
            var sourcePosition = new Position {Coordinate = new Coordinate(initialX, initialY), Direction = direction};
            var expectedDestinationCoordinate = new Coordinate(finalX, finalY);

            // Act
            var destinationCoordinate = sourcePosition.MoveBackward();

            // Assert
            destinationCoordinate.ShouldNotBe(expectedDestinationCoordinate);
        }
    }
}
