using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace Test
{
    [TestClass]
    public class ActionDelegateTests
    {
        private const int Expected = 27;
        [TestMethod]
        public void When3_Then27()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                ActionAndFuncDelegates.ActionDelegateExample.ActionProgram(new List<int>() { 3});

                var result = Convert.ToInt32(sw.ToString().Trim());

                Assert.AreEqual(Expected, result);
            }
        }

        private const int Expected2 = 125;
        [TestMethod]
        public void When5_Then125()
        {
            using (var sw2 = new StringWriter())
            {
                Console.SetOut(sw2);
                ActionAndFuncDelegates.ActionDelegateExample.ActionProgram(new List<int>() { 5 });

                var result = Convert.ToInt32(sw2.ToString().Trim());

                Assert.AreEqual(Expected2, result);
            }
        }

        private const int Expected3 = 64;
        [TestMethod]
        public void When4_Then64()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                ActionAndFuncDelegates.ActionDelegateExample.ActionProgram(new List<int>() { 4 });

                var result = Convert.ToInt32(sw.ToString().Trim());

                Assert.AreEqual(Expected3, result);
            }
        }
    }
}