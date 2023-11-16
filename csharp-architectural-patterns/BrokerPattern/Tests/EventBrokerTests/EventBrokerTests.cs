using EventBroker;

namespace EventBrokerTests
{
    public class EventBrokerTests
    {
        [Fact]
        public void GivenEventBroker_WhenMainIsCalled_ThenSubscriber1ReceivesAMessage()
        {
            //Arrange
            var writer = new StringWriter();
            Console.SetOut(writer);

            //Act
            Program.Main(Array.Empty<string>());

            //Assert
            var consoleOutput = writer.ToString().Trim();
            Assert.Contains("Subscriber1 received a message: Publisher1 publishing a message for topic1.", consoleOutput);
        }

    }
}