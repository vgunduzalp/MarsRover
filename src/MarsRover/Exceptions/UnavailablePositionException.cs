using System;

namespace MarsRover.Exceptions
{
    public class UnavailablePositionException : Exception
    {
        public UnavailablePositionException(int x, int y)
            : base($"({x},{y}) position unavailable")
        {

        }
    }
}
