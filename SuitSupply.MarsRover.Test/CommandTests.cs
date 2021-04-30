using NUnit.Framework;
using Shouldly;
using SuitSupply.MarsRover.Types;

namespace SuitSupply.MarsRover.Test
{
    public class CommandTests
    {
        [TestCase('f', Command.Forward)]
        [TestCase('B', Command.Back)]
        [TestCase('L', Command.Left)]
        [TestCase('r', Command.Right)]
        public void ToCommand_ShouldMatchValidCommand(char commandCode, Command command)
        {
            // Arrange
            Command testedCommand;

            // Act
            testedCommand = commandCode.ToCommand();

            // Assert
            testedCommand.ShouldBe(command);
        }

        [TestCase('x')]
        [TestCase('P')]
        [TestCase('t')]
        [TestCase('O')]
        public void ToCommand_ShouldReturnInvalidCommand(char commandCode)
        {
            // Arrange
            Command testedCommand;

            // Act
            testedCommand = commandCode.ToCommand();

            // Assert
            testedCommand.ShouldBe(Command.Ignore);
        }
    }
}
