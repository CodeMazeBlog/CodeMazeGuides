using ActionFunctionDelegate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ActionFuncTest
{
    [TestClass]
    public class ActionFuncDelegateTest
    {
        [TestMethod]
        public void GivenTwoNumbers_WhenRunDelegateInvoked_ReturnCorrectResults()
        {
            var delegates = new ActionFuncDelegate();

            var result = delegates.RunDelegate(5, 10);

            Assert.AreEqual(15, result.IncrementedNumber, "IncrementedNumber should be 15.");
            Assert.AreEqual(15, result.AddResult, "AddResult should be 15.");

        }
    }
}
