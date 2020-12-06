using MarsRover.Enums;
using MarsRover.Exceptions;
using MarsRover.Extensions;
using MarsRover.Interfaces;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MarsRover.Parameters
{
    public static class ParameterParser
    {
        public static IParameter Parse(string parameter)
        {
            // example: 5 5
            if (new Regex("^\\d+ \\d+$").IsMatch(parameter))
            {
                string[] data = parameter.Split(" ");

                return new SetPlateauSizeParameter
                {
                    Width = data[0].ToInt32(),
                    Height = data[1].ToInt32()
                };
            }
            // example: 5 5 E
            else if (new Regex("^\\d+ \\d+ [ESWN]$").IsMatch(parameter))
            {
                string[] data = parameter.Split(" ");

                return new AddRoverParameter
                {
                    X = data[0].ToInt32(),
                    Y = data[1].ToInt32(),
                    Orientation = Enum.Parse<RoverOrientationEnum>(data[2])
                };
            }
            // example: LMMMRRMLML
            else if (new Regex("^[LRM]+$").IsMatch(parameter))
            {
                var instructions =parameter.Select(a => Enum.Parse<InstructionEnum>(a.ToString())).ToList();

                return new RoverInstuctionParameter
                {
                    Instructions = instructions
                };
            }

            throw new ParameterException(parameter);
        }

    }
}
