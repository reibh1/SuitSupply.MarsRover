using NUnit.Framework;
using Shouldly;
using SuitSupply.MarsRover.Types;

namespace SuitSupply.MarsRover.Test
{
    public class DirectionTests
    {
        [TestCase(Direction.North, Direction.West)]
        [TestCase(Direction.West, Direction.South)]
        [TestCase(Direction.South, Direction.East)]
        [TestCase(Direction.East, Direction.North)]
        public void RotateLeft_ShouldReturnNextDirectionCounterClockwise(Direction initialDirection, Direction finalDirection)
        {
            // Arrange
            Direction testedDirection;

            // Act
            testedDirection = initialDirection.RotateLeft();

            // Assert
            testedDirection.ShouldBe(finalDirection);
        }

        [TestCase(Direction.North, Direction.East)]
        [TestCase(Direction.East, Direction.South)]
        [TestCase(Direction.South, Direction.West)]
        [TestCase(Direction.West, Direction.North)]
        public void RotateRight_ShouldReturnNextDirectionClockwise(Direction initialDirection, Direction finalDirection)
        {
            // Arrange
            Direction testedDirection;

            // Act
            testedDirection = initialDirection.RotateRight();

            // Assert
            testedDirection.ShouldBe(finalDirection);
        }

        [TestCase(Direction.North, Direction.South)]
        [TestCase(Direction.West, Direction.East)]
        public void RotateLeft_ShouldNotMatchOppositeDirection(Direction initialDirection, Direction finalDirection)
        {
            // Arrange
            Direction testedDirection;

            // Act
            testedDirection = initialDirection = initialDirection.RotateRight();

            // Assert
            testedDirection.ShouldNotBe(finalDirection);
        }

        [TestCase(Direction.South, Direction.North)]
        [TestCase(Direction.East, Direction.West)]
        public void RotateRight_ShouldNotMatchOppositeDirection(Direction initialDirection, Direction finalDirection)
        {
            // Arrange
            Direction testedDirection;

            // Act
            testedDirection = initialDirection = initialDirection.RotateRight();

            // Assert
            testedDirection.ShouldNotBe(finalDirection);
        }
    }
}