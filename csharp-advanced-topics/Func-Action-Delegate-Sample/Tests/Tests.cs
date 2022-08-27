using Func_Action_Delegate_Library.Action;
using Func_Action_Delegate_Library.Func;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void WHENtwoNumbersArePassedForAddition_THENfuncDelegateReturnsSumAsString()
        {
            var funcWithSimpleMethod = new FuncWithSimpleMethod();
            funcWithSimpleMethod.calculateSum = funcWithSimpleMethod.Sum;
            Assert.AreEqual("8", funcWithSimpleMethod.calculateSum(3, 5));
        }

        [TestMethod]
        public void WHENtwoNumbersArePassedForAddition_THENfuncDelegateReturnsSum()
        {
            var funcWithSimpleMethod = new FuncWithSimpleMethod();
            funcWithSimpleMethod.calculateSum = funcWithSimpleMethod.Sum;
            Assert.AreNotEqual("18", funcWithSimpleMethod.calculateSum(3, 5));
        }

        [TestMethod]
        public void WHENmessagePassedForSubtraction_THENactionDelegateReturnsResult()
        {
            var actionWithSimpleMethod = new ActionWithSimpleMethod();
            actionWithSimpleMethod.calculateSubtraction = actionWithSimpleMethod.Subtract;
            actionWithSimpleMethod.calculateSubtraction(12, 3, 5);
            Assert.IsTrue(actionWithSimpleMethod.result < 0 ? false : true);
        }
    }
}