using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace ActionFuncDelegatesInCSharp.Tests
{
    public class ActionFuncDelegatesUnitTest
    {

        [Fact]
        public void GivenMainFunctionInProgram_WhenCreatingAllDelegates_ThenReturnExpectedOutcome()
        {
            // Arrange
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            var expectedOutcome = new string[] { "Hello World!", "", "Milk", "Bread", "Cheese", "Butter", "", "Output 1", "Output 2", "Output 3", "Output 4" };

            // Act
            Program.Main(new string[] { });

            // Assert
            var consoleOutput = sw.ToString().Split(Environment.NewLine);
            Assert.Equal(expectedOutcome, consoleOutput);
        }
    }
}