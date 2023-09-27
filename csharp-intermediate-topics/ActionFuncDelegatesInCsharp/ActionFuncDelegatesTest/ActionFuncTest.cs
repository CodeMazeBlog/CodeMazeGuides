namespace ActionFuncDelegatesInCsharp;

public class UnitTest1
{
    [Fact]
    public void LogMessage_InvokesLogMessageDelegate()
    {
        // Arrange
        var logger = new Logger();
        string loggedMessage = null;

        // Create an Action delegate that captures the logged message.
        Action<string> logMessageDelegate = (message) =>
        {
            loggedMessage = message;
        };

        // Act
        logger.LogMessage("Test message", logMessageDelegate);

        // Assert
        Assert.Equal("Test message", loggedMessage);
    }


    [Fact]
    public void AddIntegers_NoSubscribers_ReturnsSum()
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        int result = calculator.AddIntegers(10, 20);

        // Assert
        Assert.Equal(30, result);
    }

    [Fact]
    public void AddIntegers_WithSubscriber_CallsSubscriberAndReturnsSubscriberResult()
    {
        // Arrange
        var calculator = new Calculator();
        int subscriberResult = 42;

        // Subscribe to the event with a function that returns a specific value.
        calculator.OnAddIntegers += (a, b) =>
        {
            return subscriberResult;
        };

        // Act
        int result = calculator.AddIntegers(10, 20);

        // Assert
        Assert.Equal(subscriberResult, result);
    }


}