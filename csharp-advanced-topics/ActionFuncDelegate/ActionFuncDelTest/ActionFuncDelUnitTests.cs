using Microsoft.VisualStudio.TestTools.UnitTesting;
using ActionFuncDelegate;
using System;
namespace ActionFuncDelTest
{ 

    [TestClass]
    public class ActionFuncDelUnitTests
    {

        [TestMethod]
        public void givenAction_whenNotNull_thenDisplayMsg()
        {
            var displayMsg = new Action(ActionFuncMethods.DisplayMsg);

            Assert.IsNotNull(displayMsg);
        }

        [TestMethod]
        public void givenAction_whenNotNull_thenDisplay()
        {
            var display = new Action<string>(ActionFuncMethods.Display);

            Assert.IsNotNull(display);
        }

        [TestMethod]
        public void givenAction_whenNotNull_thenDisplayNumbers()
        {
            var displayNumbers = new Action<int, int>(ActionFuncMethods.DisplayNumbers);

            Assert.IsNotNull(displayNumbers);
        }

        [TestMethod]
        public void givenFunc_whenEqual_thenReturnAdditionofNumbers()
        {
            var add = new Func<int, int, int>(ActionFuncMethods.Add);

            var result = add(12, 20);

            Assert.AreEqual(32, result);
        }

        [TestMethod]
        public void givenFunc_whenEqual_thenReturnAddition()
        {
            var showaddition = new Func<int, int, string>(ActionFuncMethods.ShowAddition);

            var result = showaddition(1, 20);

            Assert.AreEqual("Sum of 1 and 20 is 21", result);
        }

        [TestMethod]
        public void givenFunc_whenEqual_thenReturnFullName()
        {
            var fullname = new Func<string, string, string>(ActionFuncMethods.FullName);

            var result = fullname("asp", "core");

            Assert.AreEqual("Full Name is asp core", result);
        }

        [TestMethod]
        public void givenFunc_whenNotNull_thenReturnRandomNumbers()
        {
            var rand = new Func<int>(ActionFuncMethods.DisplayNum);

            var result = rand();

            Assert.IsNotNull(result);
        }
    }
}