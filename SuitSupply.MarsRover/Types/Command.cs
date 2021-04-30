namespace SuitSupply.MarsRover.Types
{
    public enum Command
    {
        Forward,
        Back,
        Left,
        Right,
        Ignore
    }

    public static class CommandExtensions 
    {
        public static Command ToCommand(this char commandCode)
        {
            return commandCode switch
            {
                'F' => Command.Forward,
                'f' => Command.Forward,
                'B' => Command.Back,
                'b' => Command.Back,
                'L' => Command.Left,
                'l' => Command.Left,
                'R' => Command.Right,
                'r' => Command.Right,
                _ => Command.Ignore
            };
        }
    }
}
