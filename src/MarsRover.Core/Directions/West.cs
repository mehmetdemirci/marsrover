using MarsRover.Core.ValueObject;

namespace MarsRover.Core.Directions
{
    public class West : IDirection
    {
        public string Direction => "W";

        public RoverPosition Move(RoverPosition roverPosition)
        {
            return new RoverPosition(roverPosition.X - 1, roverPosition.Y, this.Direction);
        }

        public IDirection Left()
        {
            return new South();
        }

        public IDirection Right()
        {
            return new North();
        }
    }
}