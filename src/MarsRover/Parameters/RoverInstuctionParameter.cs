using MarsRover.Enums;
using MarsRover.Interfaces;
using System.Collections.Generic;

namespace MarsRover.Parameters
{
    public class RoverInstuctionParameter : IParameter
    {
        public List<InstructionEnum> Instructions { get; set; }
    }
}
