using MarsRover.Enums;

namespace MarsRover.Types
{
    public class RoverPosition
    {
        public RoverPosition(int x, int y, RoverOrientationEnum orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }
        public RoverOrientationEnum Orientation { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return $"{X} {Y} {Orientation.ToString()}";
        }
    }
}
