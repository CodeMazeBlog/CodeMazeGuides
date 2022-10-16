using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpActionFuncApp;
namespace CSharpActionFuncApp.Test
{
    [TestClass]
    public class ActionFuncDelegateTest
    {
        readonly ActionFuncDelegate objActionFuncDelegate;

        ActionFuncDelegateTest()
        {
            objActionFuncDelegate = new ActionFuncDelegate();
        }

        [TestMethod]
        public void TestAdddtionDelegteResultIsSuccess()
        {
            objActionFuncDelegate.Addition(5, 5);
            Assert.AreEqual(10, ActionFuncDelegate.result);
        }

        [TestMethod]
        public void TestAdditionActionDelegateAnotherwayResultIsSuccess()
        {
            objActionFuncDelegate.AdditionActionDelegateAnotherway(10, 5);
            Assert.AreEqual(15, ActionFuncDelegate.result);
        }

        [TestMethod]
        public void TestAdditionUsingFuncDelegateReturnsValue()
        {
            int sum = objActionFuncDelegate.AdditionUsingFunc(10, 10);
            Assert.AreEqual(20, sum);
        }

        [TestMethod]
        public void TestAdditionUsingFunc2DelegateReturnsValue()
        {
            int sum = objActionFuncDelegate.AdditionUsingFunc2(10, 20);
            Assert.AreEqual(30, sum);
        }
    }
}