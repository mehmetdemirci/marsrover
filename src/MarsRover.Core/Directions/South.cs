using MarsRover.Core.ValueObject;

namespace MarsRover.Core.Directions
{
    public class South : IDirection
    {
        public string Direction => "S";

        public RoverPosition Move(RoverPosition roverPosition)
        {
            return new RoverPosition(roverPosition.X, roverPosition.Y - 1, this.Direction);
        }

        public IDirection Left()
        {
            return new East();
        }

        public IDirection Right()
        {
            return new West();
        }
    }
}