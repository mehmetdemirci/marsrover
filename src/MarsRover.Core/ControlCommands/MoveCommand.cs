using MarsRover.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.ControlCommands
{
    public class MoveCommand : IControlCommand
    {
        public string ControlCommand => "M";

        public void Execute(Rover rover)
        {
            rover.Move();
        }
    }
}
