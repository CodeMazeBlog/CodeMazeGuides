using ActionAndFuncDelegatesInCsharp;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.IO;

namespace Test
{
    [TestClass]
    public class ActionDemoUnitTest
    {
        public Operations _operations;

        [TestInitialize]
        public void SetUp()
        {
            _operations = new();
        }

        [TestMethod]
        public void SayHi_Test()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Action sayHiDelegate = _operations.SayHi;
            sayHiDelegate();

            var result = stringWriter.ToString(); 

            Assert.AreEqual($"Hi, {_operations.Name}\r\n", stringWriter.ToString());
        }

        [TestMethod]
        public void SayHiToFullName_Test()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Action<string, string> sayHiToFullName = _operations.SayHiToFullName;
            sayHiToFullName("Teri", "Dactyl");

            Assert.AreEqual($"Hi, Teri Dactyl\r\n", stringWriter.ToString());
        }

        [TestMethod]
        public void SayHelloWorld_Test()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Action sayHelloWorld = delegate () { Console.WriteLine("Hello, World!"); };
            sayHelloWorld();

            Assert.AreEqual("Hello, World!\r\n", stringWriter.ToString());
        }

        [TestMethod]
        public void SayHiToName_Test()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Action<string> sayHiToName = (string name) => { Console.WriteLine($"Hi, {name}"); };
            sayHiToName("Olive");


            Assert.AreEqual("Hi, Olive\r\n", stringWriter.ToString());
        }


    }
}