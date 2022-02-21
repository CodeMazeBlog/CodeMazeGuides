using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestScenario
{
    [TestClass]
    public class UnitTestAction
    {
        [TestMethod]
        public void When_PassingSingleValue()
        {
            //Pass single input parameter
            Func<int, double> SingleFunc = SingleFuncNumber;
            var val = SingleFunc(5);

            //Length match
            Assert.AreNotEqual(val, 2200);

            //Condition check
            Assert.IsTrue(val > 0);
        }

        [TestMethod]
        public void When_PassingMultipleValue()
        {
            //Pass multiple input parameters
            Func<int, int, double> MultipleFunc = MultipleFuncNumbers;
            var val = MultipleFunc(5, 6);

            //Length match
            Assert.AreEqual(val, 30);

            //Condition check
            Assert.IsTrue(val > 0);
        }

        private static double SingleFuncNumber(int a)
        {
            return (a * 50);
        }
        private static double MultipleFuncNumbers(int a, int b)
        {
            return (a * b);
        }
    }
}
