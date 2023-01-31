using ActionAndFuncDelegates;

namespace ActionAndFuncDelegatesTests
{
    [TestClass]
    public class CalculatorTest
    {
        private readonly Calculator _target;

        public CalculatorTest()
        {
            _target = new Calculator();
        }

        [TestMethod]
        public void WhenSum_ThenItRunsWIthSuccess()
        {
            _target.Sum(1, 1);

            Assert.AreEqual(2, _target.LastResult);
            Assert.AreEqual("The result is: 2", _target.LastLogMessage);
        }
    }
}