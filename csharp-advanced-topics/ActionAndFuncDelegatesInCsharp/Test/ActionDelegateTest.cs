using ActionAndFuncDelegatesInCsharp.Func;

namespace Test
{
    [TestClass]
    public class ActionDelegateTest
    {
        #region Func delegate
        [TestMethod]
        public void WhenTwoNumbers_ThenSumThem()
        {
            FuncDelegate funcDelegate = new FuncDelegate();

            //Arrange
            int number1 = 2024;
            int number2 = 30;
            int sum = 2054;

            //Act                       
            var result = funcDelegate.Sum(number1, number2);

            // Assert
            Assert.AreEqual(sum, result);
        }

        [TestMethod]
        public void WhenTwoNumbers_ThenSum()
        {
            FuncDelegate funcDelegate = new FuncDelegate();
            Func<int, int, int> funcUsingNamedMethod = funcDelegate.Sum;

            //Arrange
            int number1 = 2024;
            int number2 = 30;
            int sum = 2054;

            //Act                       
            var result = funcUsingNamedMethod(number1, number2);

            // Assert
            Assert.AreEqual(sum, result);
        }
        #endregion
    }
}