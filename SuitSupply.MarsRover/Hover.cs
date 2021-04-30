using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SuitSupply.MarsRover.Exceptions;
using SuitSupply.MarsRover.Types;

namespace SuitSupply.MarsRover
{
    public static class Hover
    {
        public static Position BatchMove(Position position, string commandSequence, string obstacleSequence = null)
        {
            return BatchMove(position, ToQueue(commandSequence), ToCoordinateList(obstacleSequence));
        }

        public static Position BatchMove(Position position, Queue<char> commandQueue, List<Coordinate> obstacleList = null)
        {
            return IsEmpty(commandQueue) ? position : BatchMove(Move(position, commandQueue.Dequeue().ToCommand(), obstacleList), commandQueue, obstacleList);
        }

        private static bool IsEmpty(Queue<char> queue) => queue.Count == 0;

        private static Queue<char> ToQueue(string commandSequence) => new Queue<char>(commandSequence.ToCharArray());

        public static List<Coordinate> ToCoordinateList(string obstacleSequence)
        {
            if (string.IsNullOrWhiteSpace(obstacleSequence))
            {
                return null;
            }

            var obstaclePattern = @"\s*\d+\s*,\s*\d+\s*";
            var regex = new Regex(@$"^\s*\[\s*(\[{obstaclePattern}])(\s*,\s*\[{obstaclePattern}])*\s*\]\s*$", RegexOptions.Compiled);
            var match = regex.Match(obstacleSequence);

            if (!match.Success)
            {
                throw new InvalidObstacleListException();
            }
            
            regex = new Regex(obstaclePattern);
            var obstacleList = regex.Matches(obstacleSequence).Select(m => m.Value.Split(','))
                .Select(p => new Coordinate(Convert.ToInt32(p.First()), Convert.ToInt32(p.Last()))).ToList();

            return obstacleList;
        }

        private static Position Move(Position position, Command command, List<Coordinate> obstacleList = null)
        {
            var newPosition = position;

            switch (command)
            {
                case Command.Forward:
                    newPosition.Coordinate = newPosition.MoveForward();
                    break;
                case Command.Back:
                    newPosition.Coordinate = newPosition.MoveBackward();
                    break;
                case Command.Left:
                    newPosition.Direction = newPosition.Direction.RotateLeft();
                    break;
                case Command.Right:
                    newPosition.Direction = newPosition.Direction.RotateRight();
                    break;
                case Command.Ignore:
                    break;
            }
            //Console.WriteLine(position.Coordinate.X + ", " + position.Coordinate.Y + ", " + position.Direction);

            if (obstacleList?.Contains(newPosition.Coordinate) == true)
            {
                throw new CollisionException(position);
            }

            return newPosition;
        }
    }
}
