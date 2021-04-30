using System;

namespace SuitSupply.MarsRover.Exceptions
{
    public class InvalidObstacleListException : Exception
    {
        public InvalidObstacleListException() : base("Invalid format obstacle list.") { }
    }
}