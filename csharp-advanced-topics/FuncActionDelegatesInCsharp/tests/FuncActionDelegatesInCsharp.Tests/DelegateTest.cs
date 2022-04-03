using FuncActionDelegatesInCsharp.ConsoleApp;
using Xunit;

namespace FuncActionDelegatesInCsharp.Tests
{
    public class DelegateTest
    {
        [Theory]
        [InlineData(1, "func1")]
        [InlineData(2, "func2")]
        public void GivenValidDelegate_WhenDelegateProvided_ThenCorrectDelegateIsExecuted(int delegateToRun, string expectedResult)
        {
            // Arrange
            var delegates = new Delegates();

            // Act
            string result = delegates.UseDelegate(delegateToRun);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(0)]
        public void GivenInvalidDelegate_WhenDelegateProvided_ThenExceptionThrown(int delegateToRun)
        {
            // Arrange
            var delegates = new Delegates();

            // Act
            void Act() => delegates.UseDelegate(delegateToRun); 

            // Assert
            Assert.Throws<Exception>(Act);
        }

    }
}