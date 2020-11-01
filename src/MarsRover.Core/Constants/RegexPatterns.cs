using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Constants
{
    public static class RegexPatterns
    {
        public const string PlateauSizeRegex = "^[1-9]{1} [1-9]{1}$";
        public const string RoverControlRegex = "^[LMR]+$";
        public const string RoverPositionRegex = "^[0-9]{1} [0-9]{1} [NSWE]{1}$";
    }
}
