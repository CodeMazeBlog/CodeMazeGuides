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
            var funcDelegate = new FuncDelegate();

            //Arrange
            var number1 = 2024;
            var number2 = 30;
            var sum = number1 + number2;

            //Act                       
            var result = funcDelegate.Sum(number1, number2);

            // Assert
            Assert.AreEqual(sum, result);
        }

        [TestMethod]
        public void WhenTwoNumbers_ThenSum()
        {
            var funcDelegate = new FuncDelegate();
            Func<int, int, int> funcUsingNamedMethod = funcDelegate.Sum;

            //Arrange
            var number1 = 2024;
            var number2 = 30;
            var sum = number1 + number2;

            //Act                       
            var result = funcUsingNamedMethod(number1, number2);

            // Assert
            Assert.AreEqual(sum, result);
        }
        #endregion
    }
}