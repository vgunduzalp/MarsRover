using MarsRover.Exceptions;
using Xunit;

namespace MarsRover.UnitTests
{
    public class MarsContextTests
    {
        [Theory]
        [InlineData(new object[] { "5 5", "1 2 N", "LMLMLMLMM", "1 3 N" })]
        [InlineData(new object[] { "5 5", "3 3 E", "MMRMMRMRRM", "5 1 E" })]
        public void MarsContextRunCommand(string command1, string command2, string command3, string expectedPosition)
        {
            var context = new MarsContext();
            context.SendCommand(command1);
            context.SendCommand(command2);
            context.SendCommand(command3);

            Assert.NotNull(context.ActivePlateau);
            Assert.NotNull(context.ActivePlateau.ActiveRover);
            Assert.NotNull(context.ActivePlateau.ActiveRover.Position);

            var position = context.ActivePlateau.ActiveRover.Position.ToString();
            Assert.Equal(expectedPosition, position);

        }

        [Theory]
        [InlineData(new object[] { "5 5", "10 7 N" })]
        [InlineData(new object[] { "5 5", "1 6 N" })]
        [InlineData(new object[] { "5 5", "6 6 N" })]
        [InlineData(new object[] { "5 5", "9 3 N" })]
        public void MarsContextRunCommand_ShouldOutOfPlateauException_WhenWrongPosition(string command1, string command2)
        {
            var context = new MarsContext();
            context.SendCommand(command1);

            var result = Record.Exception(() => context.SendCommand(command2));

            Assert.NotNull(result);
            Assert.IsType<OutOfPlateauException>(result);

        }
    }
}
