using MarsRover.Interfaces;
using MarsRover.Types;
using System;
using System.Collections.Generic;

namespace MarsRover.Models
{
    public class Plateau : IPlateau
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public List<Rover> RoverList { get; set; } = new List<Rover>();
        public Rover ActiveRover { get; set; }
        public PlateauSize Size { get; set; }
    }
}
