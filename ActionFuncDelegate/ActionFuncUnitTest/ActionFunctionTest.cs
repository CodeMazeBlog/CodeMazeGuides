using ActionAndFuncDelegates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace ActionFuncUnitTest
{
    delegate T ArithmeticDelegates<T>(T num1, T num2);
    [TestClass]
    public class ActionFunctionTest
    {
        [TestMethod]
        public void RunDelegate_GivenTwoNumbers_ReturnCorrectResults()
        {
            var delegates = new ActionAndFucntionDelegate();

            var result = delegates.RunDelegate(5, 10);

            Assert.AreEqual(15, result.IncrementedNumber, "IncrementedNumber should be 15.");
            Assert.AreEqual(15, result.AddResult, "AddResult should be 15.");

        }
    }
}
