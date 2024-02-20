using System;
using System.IO;
using Xunit;

namespace ActionAndFuncDelegates.Tests
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
        public void WhenLoggingInformation_ShouldWriteToConsole()
        {
            // Arrange
            string info = "information";

            // Act
            string result = CaptureConsoleOutput(() => ActionDelegates.LogInformation(info));

            // Assert
            Assert.Equal($"This logs some {info} to the console", result);
        }

        [Fact]
        public void WhenLoggingError_ShouldWriteToConsole()
        {
            // Arrange
            string error = "error";

            // Act
            string result = CaptureConsoleOutput(() => ActionDelegates.LogError(error));

            // Assert
            Assert.Equal($"This logs the {error} to the console", result);
        }
    }
}
