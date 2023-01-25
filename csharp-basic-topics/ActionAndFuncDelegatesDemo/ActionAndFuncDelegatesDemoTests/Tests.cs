using ActionAndFuncDelegatesDemo;
using FluentAssertions;

namespace ActionAndFuncDelegatesDemoTests
{
    public class Tests
    {
        [Fact]
        public void WhenCallingActionDelegate_ShouldPrintDefaultText()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Program.PrintToConsoleWithoutParameter();

            stringWriter.ToString().Trim().Should().Be("Hello, World!");
        }

        [Theory]
        [InlineData("text that should be printed")]
        public void WhenCallingActionDelegate_ShouldPrintParameterText(string textToPrint)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Program.PrintToConsoleWithParameter(textToPrint);

            stringWriter.ToString().Trim().Should().Be(textToPrint);
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(1, 2, 3)]
        [InlineData(10, 10, 20)]
        public void WhenCallingFuncDelegateToAddNumbers_ShouldReturnExpectedResult(int value1, int value2, int expected)
        {
            var result = Program.Add(value1, value2);

            result.Should().Be(expected);
        }
    }
}