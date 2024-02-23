using ActionAndFuncDelegatesInCSharp;

namespace Tests
{
    public class ActionDelegatesTests
    {
        private string CaptureConsoleOutput(Action action)
        {
            using (var consoleOutput = new StringWriter())
            {
                Console.SetOut(consoleOutput);
                action.Invoke();
                return consoleOutput.ToString().Trim();
            }
        }

        [Fact]
        public void GivenAnActionDelegate_WhenStringIsProvided_ShouldLogInfoToConsole()
        {
            // Arrange
            var info = "information";

            // Act
            var result = CaptureConsoleOutput(() => ActionDelegates.LogInformation(info));

            // Assert
            Assert.Equal($"This logs some {info} to the console", result);
        }

        [Fact]
        public void GivenAnActionDelegate_WhenStringIsProvided_ShouldLogErrorToConsole()
        {
            // Arrange
            var error = "error";

            // Act
            var result = CaptureConsoleOutput(() => ActionDelegates.LogError(error));

            // Assert
            Assert.Equal($"This logs the {error} to the console", result);
        }
    }
}
