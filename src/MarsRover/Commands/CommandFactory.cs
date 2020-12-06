using MarsRover.Commands.Interfaces;
using MarsRover.Exceptions;
using MarsRover.Parameters;

namespace MarsRover.Commands
{
    public static class CommandFactory
    {

        public static ICommand GetCommand(string command)
        {
            var parameter = ParameterParser.Parse(command);

            if (parameter is SetPlateauSizeParameter)
            {
                return new SetPlateauSizeCommand(parameter);
            }
            else if (parameter is AddRoverParameter)
            {
                return new AddRoverCommand(parameter);
            }
            else if (parameter is RoverInstuctionParameter)
            {
                return new RoverInstuctionCommand(parameter);
            }

            throw new ParameterException(command);
        }


    }
}
