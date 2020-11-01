using MarsRover.Abstraction;
using MarsRover.Abstraction.CommandSplitter;
using MarsRover.Core.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace MarsRover.Domain.Entities
{
    public class Plataeu
    {
        private readonly ICommandSplitter<SurfaceSize> commandSplitter;
        public Plataeu()
        {
            this.commandSplitter = new PlateauCommandSplitter();
        }
        public SurfaceSize Size { get; private set; }

        public void Define(string surfaceSizeInput)
        {
            var result = commandSplitter.Split(surfaceSizeInput);
            Size = new SurfaceSize(result.Width, result.Height);
        }

        public override string ToString()
        {
            return $"{this.Size}";
        }
    }
}
