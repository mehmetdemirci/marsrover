using MarsRover.Core.Constants;
using MarsRover.Core.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MarsRover.Abstraction.CommandSplitter
{
    public class PlateauCommandSplitter : CommandSplitterBase<SurfaceSize>
    {
        public override Regex CommandPattern => new Regex(RegexPatterns.PlateauSizeRegex);

        protected override SurfaceSize SplitCommand(string command)
        {
            var splitCommand = command.Split(Seperators.Space);
            var width = int.Parse(splitCommand[0]);
            var height = int.Parse(splitCommand[1]);

            return new SurfaceSize(width, height);
        }
    }
}
