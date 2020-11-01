using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.ValueObject
{
    public class RoverPosition
    {
        public RoverPosition(int x, int y, string direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public string Direction { get; }
        public int X { get; }

        public int Y { get; }
        public override string ToString()
        {
            return $"{X} {Y} {Direction}";
        }
    }
}
