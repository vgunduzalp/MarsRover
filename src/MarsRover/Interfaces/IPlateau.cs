using MarsRover.Models;
using MarsRover.Types;
using System;
using System.Collections.Generic;

namespace MarsRover.Interfaces
{
    public interface IPlateau
    {
        Guid Id { get; set; }
        List<Rover> RoverList { get; set; }
        Rover ActiveRover { get; set; }
        PlateauSize Size { get; set; }
    }
}
