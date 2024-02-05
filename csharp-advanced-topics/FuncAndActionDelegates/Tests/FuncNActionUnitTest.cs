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
        public void WhenAssigningFuncDelegate_ThenExpectedResult()
        {
            var result = _funcDelegate.GetFactorial(3);

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void WhenAssigningAPrimeNumber_ThenReturnTrue()
        {
            var expectedResult = true;

            var actualResult = _actionDelegate.IsPrimeNumber(13);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void WhenAssigningNonPrimeNumber_ThenReturnFalse()
        {
            var expectedResult = false;

            var actualResult = _actionDelegate.IsPrimeNumber(10);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
