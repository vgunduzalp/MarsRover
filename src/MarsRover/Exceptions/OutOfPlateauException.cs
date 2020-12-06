using System;

namespace MarsRover.Exceptions
{
    public class OutOfPlateauException : Exception
    {
        public OutOfPlateauException(int x, int y) 
            : base($"({x},{y}) positon is out of plateau box")
        {

        }
    }
}
