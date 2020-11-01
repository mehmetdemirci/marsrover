using MarsRover.Abstraction.CommandSplitter;
using MarsRover.Core.CommandSplitter;
using MarsRover.Core.ControlCommands;
using MarsRover.Core.Directions;
using MarsRover.Core.ValueObject;
using MarsRover.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MarsRover.Core.Entities
{
    public class Rover
    {
        private readonly ICommandSplitter<RoverPosition> commandSplitter;
        private readonly ICommandSplitter<IEnumerable<IControlCommand>> controlCommandSplitter;
        private readonly Plataeu plataeu;
        private IEnumerable<IControlCommand> controls;
        private IDirection direction;

        public Rover(Plataeu plataeu, string roverStartCommand)
        {
            this.plataeu = plataeu;
            this.commandSplitter = new RoverPositionCommandSplitter();
            this.controlCommandSplitter = new RoverControlCommandSplitter();
            this.StartPosition = commandSplitter.Split(roverStartCommand);

            if (this.IsRoverInPlateau(this.StartPosition.X, this.StartPosition.Y) == false)
                throw new RoverOutsidePlateauException("Rover outside of bounds");

            this.direction = AvailableDirections.List().Single(x => x.Direction == StartPosition.Direction);
            this.CurrentPosition = StartPosition;
        }

        public string ControlsString =>string.Concat(controls.Select(x=>x.ControlCommand).ToList());
        public RoverPosition CurrentPosition { get; private set; }
        public RoverPosition StartPosition { get; private set; }
        public void Deploy()
        {
            foreach (var control in controls)
            {
                control.Execute(this);
            }
        }

        public void Move()
        {
            this.CurrentPosition = this.direction.Move(this.CurrentPosition);

            if (this.IsRoverInPlateau(this.CurrentPosition.X, this.CurrentPosition.Y) == false)
                throw new RoverOutsidePlateauException("Rover outside of bounds");
        }

        public void SetControlCommands(string command)
        {
            controls = controlCommandSplitter.Split(command);
        }

        public override string ToString()
        {
            return $"{this.CurrentPosition.X} {this.CurrentPosition.Y} {this.direction.Direction}";
        }

        public void TurnLeft()
        {
            this.direction = this.direction.Left();
            this.CurrentPosition = new RoverPosition(this.CurrentPosition.X, this.CurrentPosition.Y, this.direction.Direction);
        }

        public void TurnRight()
        {
            this.direction = this.direction.Right();
            this.CurrentPosition = new RoverPosition(this.CurrentPosition.X, this.CurrentPosition.Y, this.direction.Direction);
        }

        private bool IsRoverInPlateau(int x, int y)
        {
            return x >= 0 && x <= this.plataeu.Size.Width &&
                   y >= 0 && y <= this.plataeu.Size.Height;
        }
    }
}
