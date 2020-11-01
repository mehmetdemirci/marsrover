using MarsRover.Abstraction.CommandSplitter;
using MarsRover.Core.Directions;
using MarsRover.Core.Entities;
using MarsRover.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRover.UnitTests
{
    public class RoverTests
    {
        private Plataeu plateau;

        public RoverTests()
        {
            plateau = new Plataeu();
            plateau.Define("5 5");
        }

        [Theory]
        [InlineData("1 2 N")]
        public void WhenCreatedRoverGiven_ThenShouldDirectionNorth(string startCommand)
        {
            var rover = new Rover(plateau, startCommand);

            var expected = new North();

            Assert.Equal(expected.Direction, rover.CurrentPosition.Direction);
        }

        [Theory]
        [InlineData("1 2 N")]
        public void WhenCreatedRoverGiven_ThenShouldMove(string startCommand)
        {
            var rover = new Rover(plateau, startCommand);

            rover.Move();


            Assert.Equal(1, rover.CurrentPosition.X);
            Assert.Equal(3, rover.CurrentPosition.Y);
            Assert.Equal("N", rover.CurrentPosition.Direction);
        }

        [Theory]
        [InlineData("1 2 N")]
        public void WhenCreatedRoverGiven_ThenShouldTurnLeft(string startCommand)
        {
            var rover = new Rover(plateau, startCommand);

            rover.TurnLeft();

            Assert.Equal("W", rover.CurrentPosition.Direction);
        }

        [Theory]
        [InlineData("1 2 N")]
        public void WhenCreatedRoverGiven_ThenShouldTurnRight(string startCommand)
        {
            var rover = new Rover(plateau, startCommand);

            rover.TurnRight();

            Assert.Equal("E", rover.CurrentPosition.Direction);
        }
        [Theory]
        [InlineData("1 2 N", "LMLMLMLMM", "1 3 N")]
        [InlineData("3 3 E", "MMRMMRMRRM", "5 1 E")]
        public void WhenCreatedRoverToGivenCoordinates_ThenShouldDeployed(string startCommand, string controlCommand, string result)
        {
            var rover = new Rover(plateau, startCommand);
            rover.SetControlCommands(controlCommand);
            rover.Deploy();

            Assert.Equal(result, rover.ToString());
        }

        [Theory]
        [InlineData("6 2 N")]
        [InlineData("2 6 N")]      
        public void WhenCreatingRover_ThenShouldThrowException(string startCommand)
        {
            Assert.Throws<RoverOutsidePlateauException>(() => new Rover(plateau, startCommand));
        }

        [Theory]
        [InlineData("2 2 A")]
        public void WhenCreatingRover_ThenShouldThrowFormatException(string startCommand)
        {
            Assert.Throws<CommandFormatException>(() => new Rover(plateau, startCommand));
        }
        [Theory]
        [InlineData("0 0 N", "MMMMMM")]
        [InlineData("3 3 E", "MMM")]
        public void WhenRoverDeployedToGivenCoordinates_ThenShouldThrowException(string startCommand, string controlCommand)
        {
            var rover = new Rover(plateau, startCommand);
            rover.SetControlCommands(controlCommand);

            Assert.Throws<RoverOutsidePlateauException>(() => rover.Deploy());
        }
    }
}
