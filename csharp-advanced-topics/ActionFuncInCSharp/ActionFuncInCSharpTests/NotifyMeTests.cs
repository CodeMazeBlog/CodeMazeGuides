using System;
using AsyncFuncInCSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsyncFuncInCSharpTests
{
    [TestClass()]
    public class NotifyMeTests
    {
        [TestMethod()]
        public void SendNotificationTest()
        {
            //Arrange
            var testTime = DateTime.Now;
            var testMessage = $"Process 'Simple delegate' started at: {testTime}.";
            var nm = new Notifier(NotifyMe.SendNotification);

            //Act
            var retVal = nm("'Simple delegate' started", testTime);

            //Assert
            Assert.AreEqual(retVal, testMessage);
        }
    }
}