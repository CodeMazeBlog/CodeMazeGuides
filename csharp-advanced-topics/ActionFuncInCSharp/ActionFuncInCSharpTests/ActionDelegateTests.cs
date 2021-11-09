using System;
using ActionFuncInCSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ActionFuncInCSharpTests
{
    [TestClass()]
    public class ActionDelegateTests
    {
        [TestMethod()]
        public void NotifyMeByActionTest()
        {
            //Arrange
            var testTime = DateTime.Now;
            var na = new Action<string, DateTime>(ActionDelegate.NotifyMeByAction);

            //Act
            na("started", testTime);

            //Assert
            Assert.IsTrue(na.Method.Name == "NotifyMeByAction");
        }
    }
}