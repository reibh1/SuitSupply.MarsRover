using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;
using SuitSupply.MarsRover.Exceptions;
using SuitSupply.MarsRover.Types;

namespace SuitSupply.MarsRover.Test
{
    public class HoverTests
    {
        [TestCase(0, 0, Direction.North, "RFFFFFRFFFFFLFFFFFRFFFFF", 10, 10, Direction.South)]
        [TestCase(100, 100, Direction.East, "FBFBFBRR", 100, 100, Direction.West)]
        [TestCase(-50, -30, Direction.East, "FLFRFLFRFLFRFLFRFLFR", -45, -35, Direction.East)]
        public void BatchMove_ShouldMatchCoordinateAndDirection(int initialX,  int initialY, Direction initialDirection, string commandSequence,
            int finalX, int finalY, Direction finalDirection)
        {
            // Arrange
            var initialPosition = new Position {Coordinate = new Coordinate(initialX, initialY), Direction = initialDirection};
            var finalPosition = new Position {Coordinate = new Coordinate(finalX, finalY), Direction = finalDirection};

            // Act
            var testedPosition = Hover.BatchMove(initialPosition, commandSequence);

            // Assert
            testedPosition.ShouldBe(finalPosition);
        }

        [TestCase(100, 100, Direction.East, "FBFBFBRRRR")]
        [TestCase(5, 5, Direction.West, "F-B-L-R-L-R-F-F-F-B-B-B")]
        [TestCase(7, 2, Direction.North, "F F R F F R F F R F F R")]
        [TestCase(-10, -20, Direction.South, "FFFFFFFFFF LL FFFFF RR BBBBB")]
        public void BatchMove_ShouldMoveALotAndReturnToSamePosition(int initialX,  int initialY, Direction initialDirection, string commandSequence)
        {
            // Arrange
            var initialPosition = new Position {Coordinate = new Coordinate(initialX, initialY), Direction = initialDirection};

            // Act
            var testedPosition = Hover.BatchMove(initialPosition, commandSequence);

            // Assert
            testedPosition.ShouldBe(initialPosition);
        }


        [TestCase("[[1, 2], [3, 4], [5, 6]]", 1, 2, 3, 4, 5,6)]
        [TestCase("[[10 , 10 ], [ 20 , 20] , [ 30, 30]]", 10, 10, 20, 20, 30,30)]
        [TestCase("[[800 , 600 ], [ 1024 , 768] , [ 1920, 1080]]", 800, 600, 1024, 768, 1920,1080)]
        public void ToCoordinateList_ShouldMatchCoordinates(string obstacleSequence,  int obstacle1X, int obstacle1Y, int obstacle2X, int obstacle2Y,
            int obstacle3X, int obstacle3Y)
        {
            // Arrange
            var expectedCoordinates = new List<Coordinate>
            {
                new Coordinate(obstacle1X, obstacle1Y),
                new Coordinate(obstacle2X, obstacle2Y),
                new Coordinate(obstacle3X, obstacle3Y)
            };

            // Act
            var coordinateList = Hover.ToCoordinateList(obstacleSequence);

            // Assert
            coordinateList.ShouldBe(expectedCoordinates);
        }

        [TestCase(0, 0, Direction.North, "RFFFFFRFFFFFLFFFFFRFFFFF", "[[10, 10]]")]
        public void BatchMove_ShouldHitFirstObstacle(int initialX,  int initialY, Direction initialDirection, string commandSequence, string obstacleSequence)
        {
            // Arrange
            var initialPosition = new Position {Coordinate = new Coordinate(initialX, initialY), Direction = initialDirection};

            // Act
            void BatchMove()
            {
                Hover.BatchMove(initialPosition, commandSequence, obstacleSequence);
            }

            //Assert
            Should.Throw<CollisionException>(BatchMove);
        }
    }
}
