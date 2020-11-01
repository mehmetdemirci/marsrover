using MarsRover.Core.Directions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRover.UnitTests
{
    public class DirectionTests
    {
        [Fact]
        public void GivenDirectionEast_WhenMove_ShouldDirectionEastAndXAxisIncremented()
        {
            var direction = new East();
            var oldPosition = new Core.ValueObject.RoverPosition(3, 3, direction.Direction);
            var position = direction.Move(oldPosition);

            Assert.Equal(position.X, oldPosition.X + 1);
            Assert.Equal(position.Y, oldPosition.Y);
        }

        [Fact]
        public void GivenDirectionEast_WhenTurnLeft_ShouldDirectionNorth()
        {
            var direction = new East();
            var newdirection = direction.Left().ToString();
            var expected = new North().ToString();

            Assert.Equal(expected, newdirection);
        }

        [Fact]
        public void GivenDirectionEast_WhenTurnRight_ShouldDirectionSouth()
        {
            var direction = new East();
            var newdirection = direction.Right().ToString();
            var expected = new South().ToString();

            Assert.Equal(expected, newdirection);
        }
        [Fact]
        public void GivenDirectionNorth_WhenMove_ShouldYAxisIncremented()
        {
            var direction = new North();
            var oldPosition = new Core.ValueObject.RoverPosition(3, 3, direction.Direction);
            var position = direction.Move(oldPosition);

            Assert.Equal(position.X, oldPosition.X);
            Assert.Equal(position.Y, oldPosition.Y + 1);
        }

        [Fact]
        public void GivenDirectionNorth_WhenTurnLeft_ShouldDirectionWest()
        {
            var direction = new North();
            var newdirection = direction.Left().ToString();
            var expected = new West().ToString();

            Assert.Equal(expected, newdirection);
        }

        [Fact]
        public void GivenDirectionNorth_WhenTurnRight_ShouldDirectionEast()
        {
            var direction = new North();
            var newdirection = direction.Right().ToString();
            var expected = new East().ToString();

            Assert.Equal(expected, newdirection);
        }
        [Fact]
        public void GivenDirectionSouth_WhenMove_ShouldYAxisDecremented()
        {
            var direction = new South();
            var oldPosition = new Core.ValueObject.RoverPosition(3, 3, direction.Direction);
            var position = direction.Move(oldPosition);

            Assert.Equal(position.X, oldPosition.X);
            Assert.Equal(position.Y, oldPosition.Y - 1);
        }

        [Fact]
        public void GivenDirectionSouth_WhenTurnLeft_ShouldDirectionEast()
        {
            var direction = new South();
            var newdirection = direction.Left().ToString();
            var expected = new East().ToString();

            Assert.Equal(expected, newdirection);
        }

        [Fact]
        public void GivenDirectionSouth_WhenTurnRight_ShouldDirectionWest()
        {
            var direction = new South();
            var newdirection = direction.Right().ToString();
            var expected = new West().ToString();

            Assert.Equal(expected, newdirection);
        }
        [Fact]
        public void GivenDirectionWest_WhenMove_ShouldXAxisDecremented()
        {
            var direction = new West();
            var oldPosition = new Core.ValueObject.RoverPosition(3, 3, direction.Direction);
            var position = direction.Move(oldPosition);

            Assert.Equal(position.X, oldPosition.X - 1);
            Assert.Equal(position.Y, oldPosition.Y);
        }

        [Fact]
        public void GivenDirectionWest_WhenTurnLeft_ShouldDirectionSouth()
        {
            var direction = new West();
            var newdirection = direction.Left().ToString();
            var expected = new South().ToString();

            Assert.Equal(expected, newdirection);
        }

        [Fact]
        public void GivenDirectionWest_WhenTurnRight_ShouldDirectionNorth()
        {
            var direction = new West();
            var newdirection = direction.Right().ToString();
            var expected = new North().ToString();

            Assert.Equal(expected, newdirection);
        }
    }
}
