using MarsRover.Abstraction.CommandSplitter;
using MarsRover.Core.Constants;
using MarsRover.Core.ControlCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MarsRover.Core.CommandSplitter
{
    public class RoverControlCommandSplitter : CommandSplitterBase<IEnumerable<IControlCommand>>
    {
        public override Regex CommandPattern => new Regex(RegexPatterns.RoverControlRegex);

        protected override IEnumerable<IControlCommand> SplitCommand(string command)
        {
            var commandList = command.Select(x => x.ToString()).ToList();
            var controlCommandList = new List<IControlCommand>();
            foreach (var cmd in commandList)
            {
               var controlCommand =  AvailableControlCommands.List().Single(x => x.ControlCommand == cmd);
                controlCommandList.Add(controlCommand);
            }

            return controlCommandList;
        }
    }
}
