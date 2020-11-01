using MarsRover.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.ControlCommands
{
    public class RotateRightCommand : IControlCommand
    {
        public string ControlCommand => "R";

        public void Execute(Rover rover)
        {
            rover.TurnRight();
        }
    }
}
