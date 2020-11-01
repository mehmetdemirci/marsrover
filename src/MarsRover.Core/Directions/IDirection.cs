using MarsRover.Core.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Directions
{
    public interface IDirection
    {
        string Direction { get; }
        IDirection Left();
        IDirection Right();
        RoverPosition Move(RoverPosition roverPosition);
    }
}
