using MarsRover.Commands.Interfaces;
using MarsRover.Exceptions;
using MarsRover.Interfaces;
using MarsRover.Models;
using MarsRover.Parameters;
using MarsRover.Types;

namespace MarsRover.Commands
{
    /// <summary>
    /// Set plateau size
    /// </summary>
    public class SetPlateauSizeCommand : ICommand
    {
        public SetPlateauSizeParameter Parameters { get; }
        public SetPlateauSizeCommand(IParameter parameters)
        {
            Parameters = (SetPlateauSizeParameter)parameters;
        }

        public void RunCommand(Plateau plateau)
        {
            if (Parameters.Width < 1 || Parameters.Height < 1)
            {
                throw new OutOfPlateauException(Parameters.Width, Parameters.Height);
            }

            plateau.Size = new PlateauSize(Parameters.Width, Parameters.Height);
        }
    }
}
