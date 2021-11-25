using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;

namespace Delegates.Tests
{
    [TestClass]
    public class ActionExampleUnitTest
    {
        static void MyAddFuction(int x, int y)
        {
            Console.Write($"{x + y}");
        }

        [TestMethod]
        public void givenActionDelegate_whenSendingParameters_thenConsoleOutputEqual()
        {
            var currentConsoleOut = Console.Out;

            using (var consoleOutput = new ConsoleOutput())
            {
                Action<int, int> actionDelegate = MyAddFuction;               
                actionDelegate(2, 3);

                Assert.AreEqual("5", consoleOutput.GetOuput());
            }

            Assert.AreEqual(currentConsoleOut, Console.Out);
        }
 
    }
    public class ConsoleOutput : IDisposable
    {
        private StringWriter stringWriter;
        private TextWriter originalOutput;

        public ConsoleOutput()
        {
            stringWriter = new StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(stringWriter);
        }

        public string GetOuput()
        {
            return stringWriter.ToString();
        }

        public void Dispose()
        {
            Console.SetOut(originalOutput);
            stringWriter.Dispose();
        }
    }
}
