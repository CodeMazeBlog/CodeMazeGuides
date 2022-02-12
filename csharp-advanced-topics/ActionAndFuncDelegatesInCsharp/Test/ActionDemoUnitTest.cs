using ActionAndFuncDelegatesInCsharp;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.IO;

namespace Test
{
    [TestClass]
    public class ActionDemoUnitTest
    {
        private Operations _operations;

        [TestInitialize]
        public void SetUp()
        {
            _operations = new();
        }

        [TestMethod]
        public void WhenDelegateSayHi_ThenWriteHiWithNameValue()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Action sayHiDelegate = _operations.SayHi;
            sayHiDelegate();
            Assert.AreEqual($"Hi, {_operations.Name}\n", stringWriter.ToString());
        }

        [TestMethod]
        public void WhenDelegateSayHiToFullName_ThenWriteHiWithFullNameValues()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Action<string, string> sayHiToFullName = Operations.SayHiToFullName;
            sayHiToFullName("Teri", "Dactyl");
            Assert.AreEqual($"Hi, Teri Dactyl\n", stringWriter.ToString());
        }

        [TestMethod]
        public void WhenDelegateAnonymouslySayHelloWorld_ThenWriteHelloWorld()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Action sayHelloWorld = delegate () { Console.WriteLine("Hello, World!"); };
            sayHelloWorld();
            Assert.AreEqual("Hello, World!\n", stringWriter.ToString());
        }

        [TestMethod]
        public void WhenDeleGateSayHiToName_ThenWriteHiToGivenName()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Action<string> sayHiToName = (string name) => { Console.WriteLine($"Hi, {name}"); };
            sayHiToName("Olive");
            Assert.AreEqual("Hi, Olive\n", stringWriter.ToString());
        }
    }
}