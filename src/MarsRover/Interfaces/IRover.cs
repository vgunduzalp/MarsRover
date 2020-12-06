using MarsRover.Types;
using System;

namespace MarsRover.Interfaces
{
    public interface IRover
    {
        Guid Id { get; set; }

        RoverPosition Position { get; set; }
        void Move();
        void TurnLeft();
        void TurnRight();
        string GetPosition();
    }
}
