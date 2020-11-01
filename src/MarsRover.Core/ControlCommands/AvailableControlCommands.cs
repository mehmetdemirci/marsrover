using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.ControlCommands
{
    public static class AvailableControlCommands
    {
        public static IEnumerable<IControlCommand> List()
        {
            return new List<IControlCommand>
            {
                new MoveCommand(),
                new RotateLeftCommand(),
                new RotateRightCommand(),
            };
        }
    }
}
