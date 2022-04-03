using FuncActionDelegatesInCsharp.ConsoleApp;
using Xunit;

namespace FuncActionDelegatesInCsharp.Tests
{
    public class FuncParametersTest
    {
        [Fact]
        public void WhenCallAcceptFunc_ThenValidResultReturned()
        {
            // Arrange
            var delegates = new FuncDelegatesParameters();

            // Act
            int result = delegates.CallAcceptFunc();

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]        
        public void WhenCallAcceptFuncWithParameters_ThenValidResultReturned()
        {
            // Arrange
            var delegates = new FuncDelegatesParameters();

            // Act
            int result = delegates.CallAcceptFuncWithParameters();

            // Assert
            Assert.Equal(7, result);
        }

        [Fact]
        public void WhenCallAcceptFuncWithParametersLambda_ThenValidResultReturned()
        {
            // Arrange
            var delegates = new FuncDelegatesParameters();

            // Act
            int result = delegates.CallAcceptFuncWithParametersLambda();

            // Assert
            Assert.Equal(7, result);

        }

        [Theory]
        [MemberData(nameof(TestCaseProvider.TestCases), MemberType = typeof(TestCaseProvider))]
        public void GivenDifferentLambdas_WhenAcceptFuncWithParameters_ThenValidResultReturned(Func<int, int, int> testLambda, int expectedResult)
        {
            // Arrange
            var delegates = new FuncDelegatesParameters();

            // Act
            int result = delegates.AcceptFuncWithParameters(testLambda);

            // Assert
            Assert.Equal(expectedResult, result);

        }

    }

    public class TestCaseProvider
    {
        public static IEnumerable<object[]> TestCases
        {
            get
            {
                yield return new object[] { (Func<int, int, int>)((a, b) => a + b), 7 };
                yield return new object[] { (Func<int, int, int>)((a, b) => a - b), -3 };
                yield return new object[] { (Func<int, int, int>)((a, b) => a + b + 1), 8 };
                yield return new object[] { (Func<int, int, int>)((a, b) => a * b), 10 };
            }
        }
    }
}