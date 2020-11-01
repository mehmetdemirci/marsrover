using MarsRover.Abstraction;
using MarsRover.Abstraction.CommandSplitter;
using MarsRover.Domain.Entities;
using Xunit;

namespace MarsRover.UnitTests
{
    public class PlateauTests
    {
        [Theory]
        [InlineData("5 5", 5, 5)]
        [InlineData("1 1", 1, 1)]
        [InlineData("2 9", 2, 9)]
        [InlineData("5 1", 5, 1)]
        public void WhenCoordinatesAreGiven_ThenShouldDefinePlateau(string command, int width, int height)
        {
            // Arrange
            var plataeu = new Plataeu();

            // Act
            plataeu.Define(command);

            // Assert
            Assert.Equal(width, plataeu.Size.Width);
            Assert.Equal(height, plataeu.Size.Height);
        }

        [Theory]
        [InlineData("55")]
        [InlineData("")]
        [InlineData(null)]
        public void WhenCoordinatesAreGiven_ThenShouldThrowException(string command)
        {
            // Arrange
            var plataeu = new Plataeu();

            // Act, Assert
            Assert.Throws<CommandFormatException>(() => plataeu.Define(command));
        }
    }
}
