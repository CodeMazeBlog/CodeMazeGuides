using System;
using Xunit;
using FuncAndActionDelegate;

namespace Tests
{
    public class FuncAndActionDelegateUnitTest
    {
        [Fact(DisplayName = "WhenSimpleFuncIsCalled_ThenReturnSumOfNumbers")]
        public void WhenSimpleFuncIsCalled_ThenReturnSumOfNumbers()
        {
            // Arrange
            FuncDelegate del = new FuncDelegate();

            // Act
            float result = del.SimpleFuncDelegate();

            //Assert
            Assert.Equal(20, result);
        }

        [Fact(DisplayName = "WhenLambdaFuncIsCalled_ThenReturnSumOfNumbers")]
        public void WhenLambdaFuncIsCalled_ThenReturnSumOfNumbers()
        {
            // Arrange
            FuncDelegate del = new FuncDelegate();

            // Act
            float result = del.FuncDelegateWithLambda();

            //Assert
            Assert.Equal(20, result);
        }
    }
}
