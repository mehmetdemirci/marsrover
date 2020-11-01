using MarsRover.Abstraction.CommandSplitter;
using MarsRover.Core.ValueObject;
using Xunit;

namespace MarsRover.UnitTests
{
    public class PlateauCommandSplitterTests
    {
        [Theory]
        [InlineData("9 9", 9, 9)]
        [InlineData("5 5", 5, 5)]
        [InlineData("1 3", 1, 3)]
        [InlineData("4 2", 4, 2)]
        public void WhenCoordinatesAreGiven_ThenShouldCommandSplit(string command, int width, int height)
        {
            // Arrange
            ICommandSplitter<SurfaceSize> commandSplitter = new PlateauCommandSplitter();

            // Act
            var commandResult = commandSplitter.Split(command);

            // Assert
            Assert.Equal(width, commandResult.Width);
            Assert.Equal(height, commandResult.Height);
        }

        [Theory]
        [InlineData("10 10")]
        [InlineData("0 0")]
        [InlineData("-5 -5")]
        [InlineData("5  5")]
        [InlineData("13")]
        [InlineData("")]
        [InlineData(null)]
        public void WhenNotMatchedCoordinatesAreGiven_ThenShouldThrowCommandSplit(string command)
        {
            // Arrange
            ICommandSplitter<SurfaceSize> commandSplitter = new PlateauCommandSplitter();

            // Act, Assert
            Assert.Throws<CommandFormatException>(() => commandSplitter.Split(command));
        }
    }
}
