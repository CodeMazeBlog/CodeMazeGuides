using Microsoft.VisualStudio.TestTools.UnitTesting;
using AsyncAndFuncInCsharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndFuncInCsharp.Tests
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