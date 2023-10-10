namespace Tests
{
    public class LoggerTests
    {
        [Fact]
        public void GivenMessageAndLogDelegate_WhenLogMessageCalled_ThenDelegateIsInvoked()
        {
            // Arrange
            var logger = new Logger();

            string? loggedMessage = null;
            string? consoleOutput = null;

            // Redirect console output to a StringWriter
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Create an Action delegate that captures the logged message
                Action<string> logMessageDelegate = (message) =>
                {
                    loggedMessage = message;
                    Console.WriteLine(message); // This line is important to capture the output
                };

                // Act
                logger.LogMessage("Test message", logMessageDelegate);

                // Get the console output
                consoleOutput = sw.ToString();
            }

            // Assert
            Assert.Equal("Test message", loggedMessage);
            Assert.Contains("Test message", consoleOutput);
        }
    }
}
