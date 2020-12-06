using System;

namespace MarsRover.Exceptions
{
    public class ParameterException : Exception
    {
        public ParameterException(string parameter) : base($"{parameter} is invalid")
        {

        }
    }
}
