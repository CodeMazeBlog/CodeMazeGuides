using FuncAndAction;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Tests
{


    [TestClass]
    public class Tests : IDisposable
    {
        StringWriter sw;

        public Tests()
        {
            sw = new StringWriter();
            Console.SetOut(sw);
            Console.SetError(sw);
        }

        public void Dispose()
        {
            sw.Dispose();
            Console.SetOut(Console.Out);
            Console.SetError(Console.Error);
        }

        [TestMethod]
        public void SimpleDelegate_ExecuteMethod()
        {
            new DelegateExample().Run();
            string result = sw.ToString().Replace(Environment.NewLine, "").Trim();
            Assert.AreEqual("12345", result);
        }

        [TestMethod]
        public void MulticastDelegate_ExecuteMethod()
        {
            new MulticastDelegateExample().Run();
            string result = sw.ToString().Replace(Environment.NewLine, "").Trim();
            Assert.AreEqual("11012102310341045105", result);
        }

        [TestMethod]
        public void ActionDelegate_ExecuteMethod()
        {
            new ActionExample().Run();
            string result = sw.ToString().Replace(Environment.NewLine, "").Trim();
            Assert.AreEqual("12345", result);
        }

        [TestMethod]
        public void FuncDelegate_ExecuteMethod()
        {
            new FuncExample().Run();
            string result = sw.ToString().Replace(Environment.NewLine, "").Trim();
            Assert.AreEqual("12345Hello World", result);
        }

        [TestMethod]
        public void ListWithAction_ExecuteMethod()
        {
            new ListWithActionExample().Run();
            string result = sw.ToString().Replace(Environment.NewLine, "").Trim();
            Assert.AreEqual("12345", result);
        }
    }
}
