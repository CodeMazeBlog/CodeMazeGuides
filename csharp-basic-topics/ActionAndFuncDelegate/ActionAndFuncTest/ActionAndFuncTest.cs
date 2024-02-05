using ActionAndFunc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ActionAndFuncTest
{
    [TestClass]
    public class ActionAndFuncTest
    {
        [TestMethod]
        public void GivenTwoNumbers_WhenRunDelegateInvoked_ReturnCorrectResults()
        {
            var delegates = new ActionAndFunction();

            var result = delegates.RunDelegate(5, 10);

            Assert.AreEqual(15, result.IncrementedNumber, "IncrementedNumber should be 15.");
            Assert.AreEqual(15, result.AddResult, "AddResult should be 15.");
        }  
    }
}
