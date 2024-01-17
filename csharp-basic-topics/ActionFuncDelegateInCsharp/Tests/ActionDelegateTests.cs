using ActionFuncDelegateInCsharp;

namespace Tests
{
    public class ActionDelegateTests
    {
        [Fact]
        public void Given_WhenMethodCalled_ThenMessageShouldBeWritten()
        {
            // Arrange
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            ActionDelegate.MethodToBeCalled();

            // Assert
            Assert.Equal("MethodToBeCalled() was called." + Environment.NewLine, output.ToString());
        }

        [Fact]
        public void GivenTwoNumbers_ThenShouldBeAdded()
        {
            // Arrange
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            ActionDelegate.AddNumbers(2, 5);

            // Assert
            Assert.Equal("Sum of 2 and 5 is: 7" + Environment.NewLine, output.ToString());
        }

        [Fact]
        public void Given_WhenDisplayMessage_ThenShouldWriteCorrectMessage()
        {
            // Arrange
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            ActionDelegate.DisplayMessage("Test Message");

            // Assert
            Assert.Equal("Message: Test Message" + Environment.NewLine, output.ToString());
        }
    }
}