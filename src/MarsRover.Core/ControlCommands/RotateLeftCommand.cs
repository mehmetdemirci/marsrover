using MarsRover.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.ControlCommands
{
    public class RotateLeftCommand : IControlCommand
    {
        public string ControlCommand => "L";

        public void Execute(Rover rover)
        {
            rover.TurnLeft();
        }
    }
}
