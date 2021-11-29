using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Delegates.Tests
{
    [TestClass]
    public class DelegateExampleUnitTest
    {
        delegate void MyDelegateMathFuction(int x, int y);
        static void MyAddFuction(int x, int y)
        {
            Console.Write($"{x + y}");
        }

        [TestMethod]
        public void givenDelegate_whenSendingParameters_thenConsoleOutputEqual()
        {
            var currentConsoleOut = Console.Out;

            using (var consoleOutput = new ConsoleOutput())
            {
                MyDelegateMathFuction delFunction = null;

                delFunction = new MyDelegateMathFuction(MyAddFuction);
                delFunction.Invoke(2, 3);

                Assert.AreEqual("5", consoleOutput.GetOuput());
            }

            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

    }
}
