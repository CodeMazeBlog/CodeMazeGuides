using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DelegateDemo;

namespace DemoTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Test_AddNumber()
        {


            // Program dm = new Program();
            //var res = dm.AddNumber(10);
            Assert.AreEqual<int>(Program.AddNumber(10), 110);
        }

        [TestMethod]
        public void Test_MultiplyNumber()
        {
            // Program dm = new Program();
            // int res = dm.MultiplyNumber(10);
            Assert.AreEqual(Program.MultiplyNumber(10), 20);
        }

        [TestMethod]
        public void Test_PrintHelloWorld()
        {

            Assert.AreEqual(Program.PrintHelloWorld(), "Hello World");
        }

        [TestMethod]
        public void Test_CalculateNumbers()
        {
            
            Assert.AreEqual(Program.CalculateNumbers(10.2, 2.2), 22);
        }
    }
}
