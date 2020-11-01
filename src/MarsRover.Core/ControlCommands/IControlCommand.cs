using MarsRover.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.ControlCommands
{
    public interface IControlCommand
    {
        string ControlCommand { get; }
        void Execute(Rover rover);
    }
}
