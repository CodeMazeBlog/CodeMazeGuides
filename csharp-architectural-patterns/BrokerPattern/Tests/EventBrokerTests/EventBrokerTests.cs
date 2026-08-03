namespace EventBrokerTests;

public class EventBrokerTests
{
    [Fact]
    public void GivenEventBroker_WhenMainIsCalled_ThenSubscriber1ReceivesAMessage()
    {
        //Arrange
        using var console = new OverrideConsoleOut();

        //Act
        Program.Main();

        //Assert
        var consoleOutput = console.Output;
        Assert.Contains("Subscriber1 received a message: Publisher1 publishing a message for topic1.", consoleOutput);
    }

    private sealed class OverrideConsoleOut : IDisposable
    {
        private readonly TextWriter _currentOut;
        private readonly StringWriter _writer;

        public OverrideConsoleOut()
        {
            _writer = new StringWriter();

            _currentOut = Console.Out;
            Console.SetOut(_writer);
        }

        public string Output => _writer.ToString();

        public void Dispose()
        {
            Console.SetOut(_currentOut);
            _writer.Dispose();
        }
    }
}