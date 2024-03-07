using ActionFuncDelegate;
using static ActionFuncDelegate.NumberAddition;

namespace Tests
{
    [TestClass]
    public class ActionFuncDelegateTests
    {
        [TestMethod]
        public void GivenTwoNumbers_WhenDelegateInvoked_ThenExpectSumOfNumbers()  
        {
            var numberAddition = new NumberAddition();
            var addNumDelegate = new AddNumDelegate(numberAddition.AddWithDelegate);
            var actualResultWithDelegate = addNumDelegate(10, 20);

            Assert.AreEqual(30, actualResultWithDelegate);
        }

        [TestMethod]
        public void GivenTwoNumbers_WhenActionDelegateInvoked_ThenSumOfNumbers()
        {
            Action<int, int> actionDelegate = new Action<int, int>(NumberAddition.AddWithActionDelegate);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GivenTwoNumbers_WhenFuncDelegateInvoked_ThenExpectSumOfNumbers()
        {
            Func<int, int, int> addNumberFuncDelegate = NumberAddition.AddWithFuncDelegate;
            var actualResultWithFuncDel = 0;
            actualResultWithFuncDel = addNumberFuncDelegate(30, 50);

            Assert.AreEqual(80, actualResultWithFuncDel);
        }
    }
}