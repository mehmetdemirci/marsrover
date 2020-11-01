using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Entities
{
    public class RoverOutsidePlateauException : Exception
    {
        public RoverOutsidePlateauException(string message) : base(message)
        {
        }
    }
}
