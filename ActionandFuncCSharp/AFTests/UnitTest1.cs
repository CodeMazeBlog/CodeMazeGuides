using AFDemo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AFTests
{
    [TestClass]
    public class UnitTest1
    {
        public CustomCountdown countdown;
        


        [TestMethod]
        public void CountdownActionTest()
        {
            Action hello  = LogHello;
            countdown = new CustomCountdown(10, hello);
            var invocations = countdown.Callbackaction.GetInvocationList();
            Assert.AreEqual(invocations.Length, 1);
        }

        public void LogHello()
        {
            Console.WriteLine("Hello");
        }



    }
}
