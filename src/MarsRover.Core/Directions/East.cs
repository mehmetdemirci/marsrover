using MarsRover.Core.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Directions
{
    public class East : IDirection
    {
        public string Direction => "E";

        public RoverPosition Move(RoverPosition roverPosition)
        {
            return new RoverPosition(roverPosition.X + 1, roverPosition.Y, this.Direction);
        }

        public IDirection Left()
        {
            return new North();
        }

        public IDirection Right()
        {
            return new South();
        }
    }
}
