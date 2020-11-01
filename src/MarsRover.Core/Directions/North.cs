using MarsRover.Core.ValueObject;

namespace MarsRover.Core.Directions
{
    public class North : IDirection
    {
        public string Direction => "N";

        public RoverPosition Move(RoverPosition roverPosition)
        {
            return new RoverPosition(roverPosition.X, roverPosition.Y + 1, this.Direction);
        }

        public IDirection Left()
        {
            return new West();
        }

        public IDirection Right()
        {
            return new East();
        }
    }
}