using MarsRover.Abstraction.CommandSplitter;
using MarsRover.Core.CommandSplitter;
using MarsRover.Core.ValueObject;
using Xunit;

namespace MarsRover.UnitTests
{
    public class RoverPositionCommandSplitterTests
    {
        [Theory]
        [InlineData("0 0 N", 0, 0, "N")]
        [InlineData("5 5 E", 5, 5, "E")]
        [InlineData("1 3 S", 1, 3, "S")]
        [InlineData("4 2 W", 4, 2, "W")]
        public void WhenCoordinatesAndDirectionAreGiven_ThenShouldCommandSplit(string command, int x, int y, string direction)
        {
            // Arrange
            ICommandSplitter<RoverPosition> commandSplitter = new RoverPositionCommandSplitter();

            // Act
            var commandResult = commandSplitter.Split(command);

            // Assert
            Assert.Equal(x, commandResult.X);
            Assert.Equal(y, commandResult.Y);
            Assert.Equal(direction, commandResult.Direction);
        }

        [Theory]
        [InlineData("10 10 X")]
        [InlineData("0 0 A")]
        [InlineData("-5 -5 N")]
        [InlineData("5  5")]
        [InlineData("13")]
        [InlineData("")]
        [InlineData(null)]
        public void WhenNotMatchedCoordinatesAndDirectionAreGiven_ThenShouldThrowCommandSplit(string command)
        {
            // Arrange
            ICommandSplitter<SurfaceSize> commandSplitter = new PlateauCommandSplitter();

            // Act, Assert
            Assert.Throws<CommandFormatException>(() => commandSplitter.Split(command));
        }
    }
}
