namespace ActionFuncDelegatesInCSharp.Tests
{
    public class ActionFuncDelegatesTest
    {
        [Fact]
        public void GivenMainFunctionInProgram_WhenCreatingAllDelegates_ThenReturnExpectedOutcome()
        {
            // Arrange
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            var expectedOutcome = "Hello World!\r\n\r\nMilk\r\nBread\r\nCheese\r\nButter\r\n\r\nOutput 1\r\nOutput 2\r\nOutput 3\r\nOutput 4";

            // Act
            Program.Main(null);

            // Assert
            string consoleOutput = sw.ToString().Trim();
            Assert.Equal(expectedOutcome, consoleOutput);
        }
    }
}