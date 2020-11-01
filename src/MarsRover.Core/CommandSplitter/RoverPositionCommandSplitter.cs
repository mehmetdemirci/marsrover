using MarsRover.Abstraction.CommandSplitter;
using MarsRover.Core.Constants;
using MarsRover.Core.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MarsRover.Core.CommandSplitter
{
    public class RoverPositionCommandSplitter : CommandSplitterBase<RoverPosition>
    {
        public override Regex CommandPattern => new Regex(RegexPatterns.RoverPositionRegex);

        protected override RoverPosition SplitCommand(string command)
        {
            var splitCommand = command.Split(Seperators.Space);
            var x = int.Parse(splitCommand[0]);
            var y = int.Parse(splitCommand[1]);
            var direction = splitCommand[2];

            return new RoverPosition(x, y, direction);
        }
    }
}
