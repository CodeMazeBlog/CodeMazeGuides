using Moq;
using static FuncAndActionDelegateInCSharp.StaticClasses.ActionDelegateExample;
using static FuncAndActionDelegateInCSharp.StaticClasses.FuncDelegateExample;

namespace FuncAndActionDelegateInCSharp.Test.Tests
{
    public class DelegateTests
    {
        /// <summary>
        /// This unit test will invoke an Action delegate
        /// As known, action delegate don't return anything as result
        /// So we'll use a flag and update it in a call back, in case the function assigned in the delegate was invoked (ran)
        /// </summary>
        /// <param name="x">First Int number used in the delegate</param>
        /// <param name="y">Second Int number used in the delegate</param>
        [Theory]
        [InlineData(5, 2)]
        public void WhenCallingActionDelegate_ThenUpdateInvokeFlag(int x, int y)
        {
            #region Arrange

            bool methodInvoked = false;
            Mock<Display> mockSumTest = new();
            mockSumTest.Setup(m => m.Invoke(x, y))
                .Callback(() =>
                {
                    methodInvoked = true;
                });

            Display display = mockSumTest.Object;

            #endregion

            #region Act

            display.Invoke(x, y);

            #endregion

            #region Assert

            Assert.True(methodInvoked);

            #endregion
        }

        /// <summary>
        /// This unit test will call the Func delegate
        /// Delegate will receive two integers, and should return the sum of those integers
        /// </summary>
        /// <param name="x">First Int number used in the delegate</param>
        /// <param name="y">Second Int number used in the delegate</param>
        [Theory]
        [InlineData(5, 2)]
        [InlineData(0, 2)]
        [InlineData(100, 6)]
        public void GivenIntNumber_WhenCallingSumDelegate_ThenReceiveSumResults(int x, int y)
        {
            #region Arrange

            IntOperations sumTest = Sum;

            #endregion

            #region Act

            var deletegateResult = sumTest.Invoke(x, y);

            #endregion

            #region Assert

            Assert.Equal(x + y, deletegateResult);

            #endregion
        }

        /// <summary>
        /// This unit test will call the Func delegate
        /// Delegate will receive two integers, and should return the multiply of those integers
        /// </summary>
        /// <param name="x">First Int number used in the delegate</param>
        /// <param name="y">Second Int number used in the delegate</param>
        [Theory]
        [InlineData(3, 2)]
        [InlineData(2, 2)]
        [InlineData(5, 6)]
        public void GivenIntNumber_WhenCallingMultiplyDelegate_ThenReceiveMultiplyResults(int x, int y)
        {
            #region Arrange

            IntOperations multiplyTest = Multiply;
            #endregion

            #region Act

            var delegateResult = multiplyTest(x, y);

            #endregion

            #region Assert

            Assert.Equal(x * y, delegateResult);

            #endregion
        }

        #region Delegate Tests Methods

        private int Sum(int x, int y) => x + y;
        private int Multiply(int x, int y) => x * y;

        #endregion

    }
}