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
    public class FuncDelegateTests
    {
        [TestMethod()]
        public void NotifyMeByFuncTest()
        {
            //Arrange
            var testTime = DateTime.Now;
            var testMessage = $"Process 'Func<T, TResult> delegate' started at: {testTime}.";
            var nf = new Func<string, DateTime, string>(FuncDelegate.NotifyMeByFunc);

            //Act
            var retVal = nf("'Func<T, TResult> delegate' started", testTime);

            //Assert
            Assert.AreEqual(retVal, testMessage);
        }
    }
}
