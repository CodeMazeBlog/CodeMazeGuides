using ActionFuncDelegateInCsharp;

namespace Tests
{
    public class ActionDelegateTests
    {
        [Fact]
        public void MethodCalled_ThenMessageShouldBeWritten()
        {
            // Arrange
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            ActionDelegate.MethodToBeCalled();

            // Assert
            var expectedMessage = "MethodToBeCalled() was called." + Environment.NewLine;
            Assert.Equal(expectedMessage, output.ToString());
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
            var expectedMessage = "Sum of 2 and 5 is: 7" + Environment.NewLine;
            Assert.Equal(expectedMessage, output.ToString());
        }

        [Fact]
        public void DisplayMessage_ThenShouldWriteCorrectMessage()
        {
            // Arrange
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            ActionDelegate.DisplayMessage("Test Message");

            // Assert
            var expectedMessage = "Message: Test Message" + Environment.NewLine;
            Assert.Equal(expectedMessage, output.ToString());
        }
    }
}