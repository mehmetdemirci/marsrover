using MarsRover.Core.ControlCommands;
using MarsRover.Core.Entities;
using MarsRover.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRover.UnitTests
{
    public class ControlCommandTests
    {

        private Plataeu plateau;

        public ControlCommandTests()
        {
            plateau = new Plataeu();
            plateau.Define("5 5");
        }

        [Fact]
        public void GivenMoveCommand_WhenExecute_ThenRoverMoved()
        {
            IControlCommand command = new MoveCommand();

            var rover = new Rover(plateau, "1 2 N");

            command.Execute(rover);

            Assert.Equal(1, rover.CurrentPosition.X);
            Assert.Equal(3, rover.CurrentPosition.Y);
            Assert.Equal("N", rover.CurrentPosition.Direction);
        }

        [Fact]
        public void GivenRotateLeftCommand_WhenExecute_ThenRoverTurnedLeft()
        {
            IControlCommand command = new RotateLeftCommand();

            var rover = new Rover(plateau, "1 2 N");

            command.Execute(rover);

            Assert.Equal(1, rover.CurrentPosition.X);
            Assert.Equal(2, rover.CurrentPosition.Y);
            Assert.Equal("W", rover.CurrentPosition.Direction);
        }

        [Fact]
        public void GivenRotateRightCommand_WhenExecute_ThenRoverTurnedRight()
        {
            IControlCommand command = new RotateRightCommand();

            var rover = new Rover(plateau, "1 2 N");

            command.Execute(rover);

            Assert.Equal(1, rover.CurrentPosition.X);
            Assert.Equal(2, rover.CurrentPosition.Y);
            Assert.Equal("E", rover.CurrentPosition.Direction);
        }
    }
}
