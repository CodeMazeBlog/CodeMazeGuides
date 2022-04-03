using FuncActionDelegatesInCsharp.ConsoleApp;
using Xunit;

namespace FuncActionDelegatesInCsharp.Tests
{
    public class FuncDelegateTest
    {
        [Theory]
        [InlineData(1, "func1")]
        [InlineData(2, "func2")]
        public void GivenValidFuncDelegate_WhenDelegateProvided_ThenCorrectDelegateIsExecuted(int delegateToRun, string expectedResult)
        {
            // Arrange
            var delegates = new FuncDelegates();

            // Act
            string result = delegates.UseDelegate(delegateToRun);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(0)]
        public void GivenInvalidFuncDelegate_WhenDelegateProvided_ThenExceptionThrown(int delegateToRun)
        {
            // Arrange
            var delegates = new FuncDelegates();

            // Act
            void Act() => delegates.UseDelegate(delegateToRun); 

            // Assert
            Assert.Throws<Exception>(Act);
        }

    }
}