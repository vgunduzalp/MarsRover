using MarsRover.Commands;
using MarsRover.Exceptions;
using MarsRover.Parameters;
using Xunit;

namespace MarsRover.UnitTests
{
    public class CommandTests
    {
        [Theory]
        [InlineData(new object[] { "1 2" })]
        [InlineData(new object[] { "4 5" })]
        [InlineData(new object[] { "2 4" })]
        public void Command_ShouldAssertSetPlateauSizeCommand_When_X_Y(string parameter)
        {
            var command = CommandFactory.GetCommand(parameter);
            Assert.IsType<SetPlateauSizeCommand>(command);
        }


        [Theory]
        [InlineData(new object[] { "MMLRML" })]
        [InlineData(new object[] { "MM" })]
        [InlineData(new object[] { "LL" })]
        public void Command_ShouldAssertRoverInstuctionCommand_When_ABC(string parameter)
        {
            var command = CommandFactory.GetCommand(parameter);
            Assert.IsType<RoverInstuctionCommand>(command);
        }


        [Theory]
        [InlineData(new object[] { "1 2 N" })]
        [InlineData(new object[] { "3 3 S" })]
        [InlineData(new object[] { "4 4 E" })]
        public void Command_ShouldAssertAddRoverCommand_When_X_Y_A(string parameter)
        {
            var command = CommandFactory.GetCommand(parameter);
            Assert.IsType<AddRoverCommand>(command);
        }


        [Theory]
        [InlineData(new object[] { "1 2 T" })]
        [InlineData(new object[] { "MMLRT" })]
        [InlineData(new object[] { "4 4 4" })]
        public void Command_ShouldAsserException(string parameter)
        {
            var result = Record.Exception(() => ParameterParser.Parse(parameter));

            Assert.NotNull(result);

            Assert.IsType<ParameterException>(result);
        }
    }
}
