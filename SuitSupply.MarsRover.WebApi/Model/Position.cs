using SuitSupply.MarsRover.Types;

namespace SuitSupply.MarsRover.WebApi.Model
{
    public class Position
    {
        public Coordinate Coordinate { get; set; }
        public Direction DirectionEnum { set => Direction = value.ToString(); }
        public string Direction { get; private set; }
    }
}
