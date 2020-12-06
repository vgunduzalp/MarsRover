using MarsRover.Commands.Interfaces;
using MarsRover.Enums;
using MarsRover.Exceptions;
using MarsRover.Interfaces;
using MarsRover.Models;
using MarsRover.Parameters;
using System;
using System.Linq;

namespace MarsRover.Commands
{
    /// <summary>
    /// Following the instructions to active rover on plateau
    /// </summary>
    public class RoverInstuctionCommand : ICommand
    {
        public RoverInstuctionParameter Parameters { get; }
        public RoverInstuctionCommand(IParameter parameters)
        {
            Parameters = (RoverInstuctionParameter)parameters;
        }

        public void RunCommand(Plateau plateau)
        {
            var rover = plateau.ActiveRover;
            if(rover == null)
            {
                throw new MarsRoverException("Plateau is empty, please send command eg: 1 3 N");
            }


            foreach (var instruction in Parameters.Instructions)
            {
                switch (instruction)
                {
                    case InstructionEnum.L:
                        rover.TurnLeft();
                        break;
                    case InstructionEnum.R:
                        rover.TurnRight();
                        break;
                    case InstructionEnum.M:
                        (int x, int y) = rover.GetExpectedPositionAfterMove();
                        if (IsThePositionAvailable(plateau, x, y))
                            rover.Move();
                        break;
                    default:
                        break;
                }
            }

            //Console.WriteLine(plateau.ActiveRover.GetPosition());

        }

        private bool IsThePositionAvailable(Plateau plateau, int x, int y)
        {
            if (x < 0 || x > plateau.Size.Width || y < 0 || y > plateau.Size.Height)
            {
                throw new OutOfPlateauException(x, y);
            }

            var unAvailablePositions = plateau.RoverList.ToDictionary(a => a.Position.X, a => a.Position.Y);

            if (unAvailablePositions != null && unAvailablePositions.Any(a => a.Key == x && a.Value == y))
            {
                throw new UnavailablePositionException(x, y);
            }

            return true;
        }
    }
}
