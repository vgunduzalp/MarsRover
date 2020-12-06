using MarsRover.Commands.Interfaces;
using MarsRover.Exceptions;
using MarsRover.Interfaces;
using MarsRover.Models;
using MarsRover.Parameters;
using MarsRover.Types;

namespace MarsRover.Commands
{
    /// <summary>
    /// Add new rover to plateau
    /// </summary>
    public class AddRoverCommand : ICommand
    {
        public AddRoverParameter Parameters { get; }
        public AddRoverCommand(IParameter parameters)
        {
            Parameters = (AddRoverParameter)parameters;
        }
        public void RunCommand(Plateau plateau)
        {
            if (plateau.Size == null)
            {
                throw new MarsRoverException("Plateau size not set, please send command eg: 5 5");
            }

            if (Parameters.X < 0 ||
                Parameters.Y < 0 ||
                Parameters.X > plateau.Size.Width ||
                Parameters.Y > plateau.Size.Height)
            {
                throw new OutOfPlateauException(Parameters.X, Parameters.Y);
            }

            var position = new RoverPosition(Parameters.X, Parameters.Y, Parameters.Orientation);

            var rover = new Rover(position);
            plateau.RoverList.Add(rover);
            plateau.ActiveRover = rover;
        }
    }
}
