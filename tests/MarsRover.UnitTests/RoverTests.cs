using MarsRover.Enums;
using MarsRover.Models;
using MarsRover.Types;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRover.UnitTests
{

    public class RoverTests
    {
        [Theory, InlineData(new object[] { 1, 2, RoverOrientationEnum.E })]
        public void RoverMove_ShouldAssert_2_2_E_When_1_2_E(int x, int y, RoverOrientationEnum orientation)
        {
            var position = new RoverPosition(x, y, orientation);
            var rover = new Rover(position);

            rover.Move();

            Assert.Equal("2 2 E", rover.GetPosition());
        }

        [Theory, InlineData(new object[] { 7, 3, RoverOrientationEnum.N })]
        public void RoverMove_ShouldAssert_7_4_N_When_1_2_N(int x, int y, RoverOrientationEnum orientation)
        {
            var position = new RoverPosition(x, y, orientation);
            var rover = new Rover(position);

            rover.Move();

            Assert.Equal("7 4 N", rover.GetPosition());
        }



        [Theory, InlineData(new object[] { RoverOrientationEnum.E })]
        public void RoverTurnLeft_ShouldAssert_N_When_E(RoverOrientationEnum orientation)
        {
            var position = new RoverPosition(0, 0, orientation);
            var rover = new Rover(position);

            rover.TurnLeft();

            Assert.Equal("N", rover.Position.Orientation.ToString());
        }

        [Theory, InlineData(new object[] { RoverOrientationEnum.S })]
        public void RoverTurnLeft_ShouldAssert_E_When_S(RoverOrientationEnum orientation)
        {
            var position = new RoverPosition(0, 0, orientation);
            var rover = new Rover(position);

            rover.TurnLeft();

            Assert.Equal("E", rover.Position.Orientation.ToString());
        }

        [Theory, InlineData(new object[] { RoverOrientationEnum.W })]
        public void RoverTurnLeft_ShouldAssert_S_When_W(RoverOrientationEnum orientation)
        {
            var position = new RoverPosition(0, 0, orientation);
            var rover = new Rover(position);

            rover.TurnLeft();

            Assert.Equal("S", rover.Position.Orientation.ToString());
        }

        [Theory, InlineData(new object[] { RoverOrientationEnum.N })]
        public void RoverTurnLeft_ShouldAssert_W_When_N(RoverOrientationEnum orientation)
        {
            var position = new RoverPosition(0, 0, orientation);
            var rover = new Rover(position);

            rover.TurnLeft();

            Assert.Equal("W", rover.Position.Orientation.ToString());
        }



        [Theory, InlineData(new object[] { RoverOrientationEnum.E })]
        public void RoverTurnRight_ShouldAssert_S_When_E(RoverOrientationEnum orientation)
        {
            var position = new RoverPosition(0, 0, orientation);
            var rover = new Rover(position);

            rover.TurnRight();

            Assert.Equal("S", rover.Position.Orientation.ToString());
        }

        [Theory, InlineData(new object[] { RoverOrientationEnum.S })]
        public void RoverTurnRight_ShouldAssert_W_When_S(RoverOrientationEnum orientation)
        {
            var position = new RoverPosition(0, 0, orientation);
            var rover = new Rover(position);

            rover.TurnRight();

            Assert.Equal("W", rover.Position.Orientation.ToString());
        }

        [Theory, InlineData(new object[] { RoverOrientationEnum.W })]
        public void RoverTurnRight_ShouldAssert_N_When_W(RoverOrientationEnum orientation)
        {
            var position = new RoverPosition(0, 0, orientation);
            var rover = new Rover(position);

            rover.TurnRight();

            Assert.Equal("N", rover.Position.Orientation.ToString());
        }

        [Theory, InlineData(new object[] { RoverOrientationEnum.N })]
        public void RoverTurnRight_ShouldAssert_E_When_N(RoverOrientationEnum orientation)
        {
            var position = new RoverPosition(0, 0, orientation);
            var rover = new Rover(position);

            rover.TurnRight();

            Assert.Equal("E", rover.Position.Orientation.ToString());
        }


    }
}
