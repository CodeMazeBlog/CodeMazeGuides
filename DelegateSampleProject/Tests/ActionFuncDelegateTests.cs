using ActionFuncDelegate;
using static ActionFuncDelegate.NumberAddition;

namespace Tests
{
    [TestClass]
    public class ActionFuncDelegateTests
    {



        [TestMethod]
        public void WhenNumberSent_DelegateExecuteTheMethod()
        {
            NumberAddition numberAddition = new NumberAddition();
            AddNumDelegate addNumDelegate = new AddNumDelegate(numberAddition.AddWithDelegate);
            int actualResultWithDelegate = addNumDelegate(10, 20);
            Assert.AreEqual(30, actualResultWithDelegate);
        }


        [TestMethod]
        public void WhenNumberSent_ActionDelegateExecuteTheMethod()
        {
            Action<int, int> actionDelegate = new Action<int, int>(NumberAddition.AddWithActionDelegate);
            Assert.IsTrue(true);
            
        }

        [TestMethod]
        public void WhenNumberSent_FuncDelegateExecuteTheMethod()
        {

            Func<int, int, int> addNumberFuncDelegate = NumberAddition.AddWithFuncDelegate;
            int actualResultWithFuncDel = 0;
            actualResultWithFuncDel = addNumberFuncDelegate(30, 50);
            Assert.AreEqual(80, actualResultWithFuncDel);

        }
    }
}