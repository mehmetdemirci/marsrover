using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Directions
{
    public static class AvailableDirections
    {
        public static IEnumerable<IDirection> List()
        {
            return new List<IDirection>
            {
                new East(),
                new North(),
                new South(),
                new West(),
            };
        }
    }
}
