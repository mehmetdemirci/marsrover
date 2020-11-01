using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Abstraction.CommandSplitter
{
    public class CommandFormatException : Exception
    {
        public CommandFormatException(string message) : base(message)
        {
        }
    }
}
