using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.ValueObject
{
    public class SurfaceSize
    {
        public SurfaceSize(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Height { get; }
        public int Width { get; }
        public override string ToString()
        {
            return $"{Width} {Height}";
        }
    }
}
