using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Test
{
    [TestClass]
    public class FuncDelegateTests
    {
        private const int Expected = 1;
        [TestMethod]
        public void WhenHi_Then1()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                ActionAndFuncDelegates.FuncDelegateExample.FuncProgram("Hi");

                var result = Convert.ToInt32(sw.ToString().Trim());

                Assert.AreEqual(Expected, result);
            }
        }

        private const int Expected2 = 2;
        [TestMethod]
        public void WhenHello_Then2()
        {
            using (var sw2 = new StringWriter())
            {
                Console.SetOut(sw2);
                ActionAndFuncDelegates.FuncDelegateExample.FuncProgram("Hello");

                var result = Convert.ToInt32(sw2.ToString().Trim());

                Assert.AreEqual(Expected2, result);
            }
        }

        private const int Expected3 = 6;
        [TestMethod]
        public void WhenHellotherefriend_Then6()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                ActionAndFuncDelegates.FuncDelegateExample.FuncProgram("Hello there friend!");

                var result = Convert.ToInt32(sw.ToString().Trim());

                Assert.AreEqual(Expected3, result);
            }
        }
    }
}