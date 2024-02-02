using FuncNActionDelegates;

namespace Tests
{
    [TestClass]
    public class FuncNActionUnitTest
    {
        private readonly FuncDelegate _funcDelegate;
        private readonly ActionDelegate _actionDelegate;
        public FuncNActionUnitTest()
        {
            _funcDelegate = new FuncDelegate();
            _actionDelegate = new ActionDelegate();
        }

        [TestMethod]
        public void TestFuncDelegate()
        {
            var result = _funcDelegate.GetFactorial(3);

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void IsPrimeNumber_ShouldReturnTrueForPrime()
        {
            bool expectedResult = true;

            bool actualResult = _actionDelegate.IsPrimeNumber(13);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsPrimeNumber_ShouldReturnFalseForNonPrime()
        {
            bool expectedResult = false;

            bool actualResult = _actionDelegate.IsPrimeNumber(10);

            Assert.AreEqual(expectedResult, actualResult);
        }


    }

}
