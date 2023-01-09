using ActionFuncDelegates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace Tests
{  

    [TestClass]
    public class ActionDelegateTests
    {
        
        private const int expectedResultTestOne = 27;
        private const int expectedResultTestTwo = 125;
        private const int expectedResultTestThree = 64;

        [TestMethod]
        public void When3_Then27()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                ActionDelegateExample.ActionProgram(new List<int>() { 3 });

                var result = Convert.ToInt32(sw.ToString().Trim());

                Assert.AreEqual(expectedResultTestOne, result);
            }
        }
        
        [TestMethod]
        public void When5_Then125()
        {
            using (var sw2 = new StringWriter())
            {
                Console.SetOut(sw2);
                ActionDelegateExample.ActionProgram(new List<int>() { 5 });

                var result = Convert.ToInt32(sw2.ToString().Trim());

                Assert.AreEqual(expectedResultTestTwo, result);
            }
        }
        
        [TestMethod]
        public void When4_Then64()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                ActionDelegateExample.ActionProgram(new List<int>() { 4 });

                var result = Convert.ToInt32(sw.ToString().Trim());

                Assert.AreEqual(expectedResultTestThree, result);
            }
        }
    }
}