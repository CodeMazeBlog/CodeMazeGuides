using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsyncAndFuncInCsharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsyncAndFuncInCsharpTests
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
