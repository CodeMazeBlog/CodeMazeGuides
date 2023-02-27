using ActionAndFuncDelegateInCSharp;

namespace Tests
{
    public class HandleFuncDelegateTests
    {
        [Fact]
        public void PrintFuncDelegate_PrintsResultToConsole()
        {
            // Arrange
            StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            HandleFuncDelegate.PrintFuncDelegate();

            // Assert
            Assert.Equal($"\nResult = 40{Environment.NewLine}", consoleOutput.ToString());
        }
    }
}
