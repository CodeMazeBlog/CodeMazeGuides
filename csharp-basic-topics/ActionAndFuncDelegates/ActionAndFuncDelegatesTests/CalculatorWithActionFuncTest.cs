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
        }
    }
}