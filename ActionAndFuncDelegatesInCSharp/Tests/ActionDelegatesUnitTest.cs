namespace Tests
{
    public class ActionDelegatesUnitTest
    {
        [Fact]
        public void WhenMessageIsLogged_ThenLogsMessageToConsole()
        {
            // Arrange
            string receivedMessage = string.Empty;
            Action<string> logMessage = message => receivedMessage = message;

            // Act
            logMessage("Hello, world!");

            // Assert
            Assert.Equal("Hello, world!", receivedMessage);
        }

        [Fact]
        public void WhenSingleWordMessageIsLogged_ThenLogsSingleWordMessageToConsole()
        {
            // Arrange
            string receivedMessage = string.Empty;
            Action<string> logMessage = message => receivedMessage = message;

            // Act
            logMessage("Hello");

            // Assert
            Assert.Equal("Hello", receivedMessage);
        }

        [Fact]
        public void WhenEmptyMessageIsLogged_ThenLogsEmptyMessageToConsole()
        {
            // Arrange
            string receivedMessage = string.Empty;
            Action<string> logMessage = message => receivedMessage = message;

            // Act
            logMessage("");

            // Assert
            Assert.Equal("", receivedMessage);
        }

        [Fact]
        public void WhenMessageWithSpecialCharactersIsLogged_ThenLogsMessageWithSpecialCharactersToConsole()
        {
            // Arrange
            string receivedMessage = string.Empty;
            Action<string> logMessage = message => receivedMessage = message;

            // Act
            logMessage("Hello, $world!");

            // Assert
            Assert.Equal("Hello, $world!", receivedMessage);
        }

        [Fact]
        public void WhenNullMessageIsLogged_ThenLogsNullMessageToConsole()
        {
            // Arrange
            string? receivedMessage = null;
            Action<string?> logMessage = message => receivedMessage = message;

            // Act
            logMessage(null);

            // Assert
            Assert.Null(receivedMessage);
        }

        [Fact]
        public void WhenMessageContainingUnicodeCharactersIsLogged_ThenLogsMessageWithUnicodeCharactersToConsole()
        {
            // Arrange
            string receivedMessage = string.Empty;
            Action<string> logMessage = message => receivedMessage = message;

            // Act
            logMessage("Hello, 你好!");

            // Assert
            Assert.Equal("Hello, 你好!", receivedMessage);
        }
    }

}