using ActionAndFuncDelegate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ActionAndFuncDelegatesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_AddMethod()
        {
            Training training = new Training();
            int res = training.Add(2, 3);
            Assert.AreEqual(5, res);
        }

        [TestMethod]
        public void Test_DisplayDate()
        {
            Training training = new Training();
            var res = $"Time is {DateTime.Now.ToString("MM/dd/yyyy")}";
            Assert.AreEqual(res, training.DisplayDate(DateTime.Now));
        }
    }
}
