using FuncAndActionsInCsharp;

namespace Tests
{
    public class ActionDelegatesTests
    {
        [Fact]
        public void WhenDisplayingMessage_ThenPrintsHelloWorld()
        {
            // Arrange
            using var writer = new StringWriter();
            Console.SetOut(writer);

            // Act
            ActionDelegates.DisplayMessage();

            // Assert
            var output = writer.GetStringBuilder().ToString().TrimEnd();
            Assert.Equal("Hello, World!", output);
        }

        [Fact]
        public void WhenGreetingWithAnonymous_ThenPrintsMessage()
        {
            // Arrange
            using var writer = new StringWriter();
            Console.SetOut(writer);

            // Act
            ActionDelegates.GreetAnonymous("Hello from anonymous method!");

            // Assert
            var output = writer.GetStringBuilder().ToString().TrimEnd();
            Assert.Equal("Hello from anonymous method!", output);
        }

        [Fact]
        public void WhenGreetingWithLambda_ThenPrintsMessage()
        {
            // Arrange
            using var writer = new StringWriter();
            Console.SetOut(writer);

            // Act
            ActionDelegates.GreetLambda("Hello from lambda expression!");

            // Assert
            var output = writer.GetStringBuilder().ToString().TrimEnd();
            Assert.Equal("Hello from lambda expression!", output);
        }
    }
}
