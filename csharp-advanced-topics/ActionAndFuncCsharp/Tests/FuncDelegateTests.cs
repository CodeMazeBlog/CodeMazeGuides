using ActionAndFuncCsharp;
using Xunit;

namespace Tests
{
    public class FuncDelegateTests
    {
        [Theory]
        [InlineData(2, 3, 8)]
        [InlineData(2, 0, 1)]
        [InlineData(5, 1, 5)]
        [InlineData(3, 4, 81)]
        public void TakePower_Should_ReturnCorrectPower(int x, int power, int expectedPower)
        {
            // Arrange
            var funcDelegate = new FuncDelegate();

            // Act
            int result = funcDelegate.TakePower(x, power);

            // Assert
            Assert.Equal(expectedPower, result);
        }

        [Theory]
        [InlineData(5, 10, "Sum of 5 and 10 is: 15")]
        [InlineData(0, 0, "Sum of 0 and 0 is: 0")]
        [InlineData(-5, 10, "Sum of -5 and 10 is: 5")]
        public void DisplaySum_Should_ReturnCorrectSum(int a, int b, string expectedSumMessage)
        {
            // Arrange
            var funcDelegate = new FuncDelegate();

            // Act
            string resultMessage = funcDelegate.DisplaySum(a, b);

            // Assert
            Assert.Equal(expectedSumMessage, resultMessage);
        }

        [Theory]
        [InlineData("Hello, ", "World!", "Hello, World!")]
        [InlineData("", "World!", "World!")]
        [InlineData("Hello, ", "", "Hello, ")]
        [InlineData("", "", "")]
        public void StringAppend_Should_ReturnCorrectAppendedString(string first, string last, string expectedAppendedString)
        {
            // Arrange
            var funcDelegate = new FuncDelegate();

            // Act
            string resultString = funcDelegate.StringAppend(first, last);

            // Assert
            Assert.Equal(expectedAppendedString, resultString);
        }
    }
}
