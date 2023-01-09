using ActionFuncDelegates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Tests
{
    [TestClass]
    public class FuncDelegateTests
    {
        private const int expectedResultTestOne = 1;
        private const int expectedResultTestTwo = 2;
        private const int expectedResultTestThree = 6;

        [TestMethod]
        public void WhenHi_Then1()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                FuncDelegateExample.FuncProgram("Hi");

                var result = Convert.ToInt32(sw.ToString().Trim());

                Assert.AreEqual(expectedResultTestOne, result);
            }
        }
        
        [TestMethod]
        public void WhenHello_Then2()
        {
            using (var sw2 = new StringWriter())
            {
                Console.SetOut(sw2);
                FuncDelegateExample.FuncProgram("Hello");

                var result = Convert.ToInt32(sw2.ToString().Trim());

                Assert.AreEqual(expectedResultTestTwo, result);
            }
        }
        
        [TestMethod]
        public void WhenHellotherefriend_Then6()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                FuncDelegateExample.FuncProgram("Hello there friend!");

                var result = Convert.ToInt32(sw.ToString().Trim());

                Assert.AreEqual(expectedResultTestThree, result);
            }
        }
    }
}