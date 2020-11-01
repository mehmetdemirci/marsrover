using MarsRover.Abstraction.CommandSplitter;
using MarsRover.Core.CommandSplitter;
using MarsRover.Core.ControlCommands;
using MarsRover.Core.ValueObject;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MarsRover.UnitTests
{
    public class RoverControlCommandSplitterTests
    {
        [Theory]
        [InlineData("LMR")]
        public void WhenControlsAreGiven_ThenShouldCommandSplit(string command)
        {
            // Arrange
            ICommandSplitter<IEnumerable<IControlCommand>> commandSplitter = new RoverControlCommandSplitter();

            // Act
            var commandResult = commandSplitter.Split(command);

            // Assert
            Assert.Equal(command.Length, commandResult.Count());
        }

        [Theory]
        [InlineData("L M R")]
        [InlineData("ABC")]
        [InlineData("")]
        [InlineData(null)]
        public void WhenNotMatchedControlsAreGiven_ThenShouldThrowCommandSplit(string command)
        {
            // Arrange
            ICommandSplitter<IEnumerable<IControlCommand>> commandSplitter = new RoverControlCommandSplitter();

            // Act, Assert
            Assert.Throws<CommandFormatException>(() => commandSplitter.Split(command));
        }
    }
}
