using SuitSupply.MarsRover.Exceptions;
using SuitSupply.MarsRover.Types;

namespace SuitSupply.MarsRover.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var position = new Position
            {
                Coordinate = new Coordinate(0, 0),
                Direction = Direction.East
            };

            try
            {
                position = Hover.BatchMove(position, "FFFFF", "[[3,1], [5, 0], [3, 5]]");
            }
            catch (CollisionException e)
            {
                System.Console.WriteLine(e.Message);
            }

            System.Console.ReadKey();
        }
    }
}
