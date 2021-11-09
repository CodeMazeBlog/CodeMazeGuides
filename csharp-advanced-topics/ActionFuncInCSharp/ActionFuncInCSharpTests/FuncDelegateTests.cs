using System;
using ActionFuncInCSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ActionFuncInCSharpTests
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