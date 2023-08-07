using ActionAndFuncCsharp;
using System.IO;
using System;
using Xunit;

namespace Tests
{
    public class ActionDelegateTests
    {
        [Fact]
        public void DisplayText_Should_PrintCorrectMessage()
        {
            // Arrange
            var actionDelegate = new ActionDelegate();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            actionDelegate.DisplayText();

            // Assert
            string expectedOutput = "Action<> - Learning Delegates is Fun - Awesome!";
            Assert.Equal(expectedOutput, stringWriter.ToString().Trim());
        }

        [Theory]
        [InlineData(10, 20, "Action<int,int> - Sum is: 30")]
        [InlineData(0, 0, "Action<int,int> - Sum is: 0")]
        [InlineData(-5, 10, "Action<int,int> - Sum is: 5")]
        public void DisplayNumbers_Should_PrintCorrectSum(int num1, int num2, string expectedOutput)
        {
            // Arrange
            var actionDelegate = new ActionDelegate();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            actionDelegate.DisplaySum(num1, num2);

            // Assert
            Assert.Equal(expectedOutput, stringWriter.ToString().Trim());
        }

        [Theory]
        [InlineData("Hassan Iftikhar", "Action<T> : Hassan Iftikhar")]
        [InlineData("Hello, Delegates!", "Action<T> : Hello, Delegates!")]
        public void DisplayMessage_Should_PrintCorrectMessage(string message, string expectedOutput)
        {
            // Arrange
            var actionDelegate = new ActionDelegate();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            actionDelegate.DisplayMessage(message);

            // Assert
            Assert.Equal(expectedOutput, stringWriter.ToString().Trim());
        }
    }
}
