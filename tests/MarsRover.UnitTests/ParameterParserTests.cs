using MarsRover.Exceptions;
using MarsRover.Parameters;
using Xunit;

namespace MarsRover.UnitTests
{
    public class ParameterParserTests
    {
        [Theory]
        [InlineData(new object[] { "LLMMRMM" })]
        [InlineData(new object[] { "RLM" })]
        [InlineData(new object[] { "MMRRMMLL" })]
        public void Parser_ShouldAssertRoverInstuction_When_LLMMRMM(string parameter)
        {
            var p = ParameterParser.Parse(parameter);
            Assert.IsType<RoverInstuctionParameter>(p);
        }

        [Theory]
        [InlineData(new object[] { "1 2 N" })]
        [InlineData(new object[] { "4 3 W" })]
        public void Parser_ShouldAssertAddRover_When_1_2_N(string parameter)
        {
            var p = ParameterParser.Parse(parameter);
            Assert.IsType<AddRoverParameter>(p);
        }

        [Theory]
        [InlineData(new object[] { "5 5" })]
        [InlineData(new object[] { "3 7" })]
        public void Parser_ShouldAssertSetPlateauSize_When_5_5(string parameter)
        {
            var p = ParameterParser.Parse(parameter);
            Assert.IsType<SetPlateauSizeParameter>(p);
        }


        [Theory]
        [InlineData(new object[] { "LLRTT" })]
        [InlineData(new object[] { "RMMLURT" })]
        public void Parser_ShouldAssertParameterException_When_LLRTT(string parameter)
        {
            var result = Record.Exception(() => ParameterParser.Parse(parameter));
            
            Assert.NotNull(result);

            Assert.IsType<ParameterException>(result);
            
        }

    }
}
