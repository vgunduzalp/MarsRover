using MarsRover.Interfaces;

namespace MarsRover.Parameters
{
    public class SetPlateauSizeParameter : IParameter
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
