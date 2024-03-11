using Xunit;

namespace Delegates.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void GivenTwoNumbers_WhenPrintStringCalled_ThenOutputShouldPrintValues()
        {
            // Arrange
            var expectedOutput = "The values are: 2 and 3";
            var consoleOutput = new System.IO.StringWriter();
            System.Console.SetOut(consoleOutput);

            // Act
            Program.ConsolePrinter.PrintString(2, 3);

            // Assert
            Assert.Equal(expectedOutput, consoleOutput.ToString().Trim());
        }

        [Fact]
        public void GivenTwoNumbers_WhenMultiplyTwoNumbersCalled_ThenResultShouldBeProduct()
        {
            // Arrange
            var expectedOutput = 6;

            // Act
            var result = Program.MultiplicationUtility.MultiplyTwoNumbers(2, 3);

            // Assert
            Assert.Equal(expectedOutput, result);
        }
    }
}
