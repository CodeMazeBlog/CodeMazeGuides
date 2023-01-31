using ActionAndFuncDelegates;

namespace ActionAndFuncDelegatesTests
{
    [TestClass]
    public class CalculatorWithActionFuncTest
    {
        private readonly CalculatorWithActionFunc _target;

        public CalculatorWithActionFuncTest()
        {
            _target = new CalculatorWithActionFunc();
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