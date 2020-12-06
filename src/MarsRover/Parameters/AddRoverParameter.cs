using MarsRover.Enums;
using MarsRover.Interfaces;

namespace MarsRover.Parameters
{
    public class AddRoverParameter : IParameter
    {
        public int X { get; set; }
        public int Y { get; set; }
        public RoverOrientationEnum Orientation { get; set; }
    }
}
