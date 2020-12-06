using MarsRover.Enums;
using MarsRover.Interfaces;
using MarsRover.Types;
using System;

namespace MarsRover.Models
{
    public class Rover : IRover
    {
        #region Properties and Ctor

        public Guid Id { get; set; } = Guid.NewGuid();
        public RoverPosition Position { get; set; }
        public Rover(RoverPosition position)
        {
            Position = position;
        }

        #endregion

        #region Public Methods

        public void Move()
        {
            switch (Position.Orientation)
            {
                case RoverOrientationEnum.E:
                    Position.X += 1;
                    break;
                case RoverOrientationEnum.S:
                    Position.Y -= 1;
                    break;
                case RoverOrientationEnum.W:
                    Position.X -= 1;
                    break;
                case RoverOrientationEnum.N:
                    Position.Y += 1;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Get expected position for check available on plateau
        /// </summary>
        /// <returns>x,y coordinate</returns>
        public (int,int) GetExpectedPositionAfterMove()
        {
            int newPositionX = Position.X;
            int newPositionY = Position.Y;
            switch (Position.Orientation)
            {
                case RoverOrientationEnum.E:
                    newPositionX += 1;
                    break;
                case RoverOrientationEnum.S:
                    newPositionY -= 1;
                    break;
                case RoverOrientationEnum.W:
                    newPositionX -= 1;
                    break;
                case RoverOrientationEnum.N:
                    newPositionY += 1;
                    break;
                default:
                    break;
            }

            return (newPositionX, newPositionY);

        }

        public void TurnLeft()
        {
            switch (Position.Orientation)
            {
                case RoverOrientationEnum.E:
                    Position.Orientation = RoverOrientationEnum.N;
                    break;
                case RoverOrientationEnum.S:
                    Position.Orientation = RoverOrientationEnum.E;
                    break;
                case RoverOrientationEnum.W:
                    Position.Orientation = RoverOrientationEnum.S;
                    break;
                case RoverOrientationEnum.N:
                    Position.Orientation = RoverOrientationEnum.W;
                    break;
                default:
                    break;
            }
        }

        public void TurnRight()
        {
            switch (Position.Orientation)
            {
                case RoverOrientationEnum.E:
                    Position.Orientation = RoverOrientationEnum.S;
                    break;
                case RoverOrientationEnum.S:
                    Position.Orientation = RoverOrientationEnum.W;
                    break;
                case RoverOrientationEnum.W:
                    Position.Orientation = RoverOrientationEnum.N;
                    break;
                case RoverOrientationEnum.N:
                    Position.Orientation = RoverOrientationEnum.E;
                    break;
                default:
                    break;
            }
        }

        public string GetPosition()
        {
            return Position.ToString();
        }

        #endregion

    }
}
