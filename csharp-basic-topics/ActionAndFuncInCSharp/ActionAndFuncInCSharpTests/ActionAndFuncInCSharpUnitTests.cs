using System;
using ActionAndFuncInCSharp;
using NUnit.Framework;
using System.IO;

namespace ActionAndFuncInCSharpTests
{
    public class ActionAndFuncInCSharpUnitTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenUsingDelegate_ThenCorrectMethodIsChosen()
        {
            var addition = Program.SimpleDelegate("Add", 3, 2);
            Assert.AreEqual(addition, 5);
            var subtraction = Program.SimpleDelegate("Subtract", 3, 2);
            Assert.AreEqual(subtraction, 1);
        }

        [Test]
        public void WhenUsingFunc_ThenCorrectMethodIsChosen()
        {
            var addition = Program.UsingFunc("Add", 3, 2);
            Assert.AreEqual(addition, 5);
            var subtraction = Program.UsingFunc("Subtract", 3, 2);
            Assert.AreEqual(subtraction, 1);
        }

        [Test]
        public void WhenUsingAction_ThenCorrectMethodIsChosen()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.UsingAction("Print", 3, 2);
                var printedOutput = sw.ToString().Trim();
                Assert.AreEqual(printedOutput, "5");
            }

            using (StringWriter sw2 = new StringWriter())
            {
                Console.SetOut(sw2);
                Program.UsingAction("NoPrint", 3, 2);
                var printedOutput2 = sw2.ToString().Trim();
                Assert.AreEqual(printedOutput2, "Ignored");
            }
        }
    

        
    }
}