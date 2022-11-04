using Microsoft.VisualStudio.TestTools.UnitTesting;
using ActionFuncDel;
using System;

namespace ActionFuncDelTest
{
    [TestClass]
    public class ActionFuncDelUnitTest
    {
        [TestMethod]
        public void Test_Action_DisplayMsg()
        {
            var displayMsg = new Action(ActionFuncMethods.DisplayMsg);
            Assert.IsNotNull(displayMsg);
        }
        [TestMethod]
        public void Test_Action_Display()
        {
            var display = new Action<string>(ActionFuncMethods.Display);
            Assert.IsNotNull(display);
        }
        [TestMethod]
        public void Test_Action_DisplayNumbers()
        {
            var displayNumbers = new Action<int, int>(ActionFuncMethods.DisplayNumbers);
            Assert.IsNotNull(displayNumbers);
        }
        [TestMethod]
        public void Test_Func_AddNumbers()
        {
            var add = new Func<int, int, int>(ActionFuncMethods.Add);
            var result = add(12, 20);
            Assert.AreEqual(32, result);
        }
        [TestMethod]
        public void Test_Func_ShowAddition()
        {
            var showaddition = new Func<int, int, string>(ActionFuncMethods.ShowAddition);
            var result = showaddition(1, 20);
            Assert.AreEqual("Sum of 1 and 20 is 21", result);
        }
        [TestMethod]
        public void Test_Func_FullName()
        {
            var fullname = new Func<string, string, string>(ActionFuncMethods.FullName);
            var result = fullname("asp", "core");
            Assert.AreEqual("Full Name is asp core", result);
        }
        [TestMethod]
        public void Test_Func_RandomNumbers()
        {
            var rand = new Func<int>(ActionFuncMethods.DisplayNum);
            var result = rand();
            Assert.IsNotNull(result);
        }
    }
}
