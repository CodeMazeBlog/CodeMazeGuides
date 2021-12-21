using System;
using Xunit;
using FuncAndActionDelegate;

namespace Tests
{
    public class FuncAndActionDelegateUnitTest
    {
        [Fact(DisplayName = "WhenSimpleFuncIsCalled_ThenItReturnSumOfNumbers")]
        public void WhenSimpleFuncIsCalled_ThenItReturnSumOfNumbers()
        {
            // Arrange
            FuncDelegate del = new FuncDelegate();

            // Act
            double result = del.SimpleFuncDelegate();

            //Assert
            Assert.Equal(20.55, result);
        }

        [Fact(DisplayName = "WhenFuncDelegateWithAnonymousMethodIsCalled_ThenItReturns50")]
        public void WhenFuncDelegateWithAnonymousMethodIsCalled_ThenItReturns50()
        {
            // Arrange
            FuncDelegate del = new FuncDelegate();

            // Act
            double result = del.FuncDelegateWithAnonymousMethods();

            //Assert
            Assert.Equal(50, result);
        }

        [Fact(DisplayName = "WhenLambdaFuncIsCalled_ThenItReturnSumOfNumbers")]
        public void WhenLambdaFuncIsCalled_ThenItReturnSumOfNumbers()
        {
            // Arrange
            FuncDelegate del = new FuncDelegate();

            // Act
            double result = del.FuncDelegateWithLambda();

            //Assert
            Assert.Equal(40.55, result);
        }
    }
}
