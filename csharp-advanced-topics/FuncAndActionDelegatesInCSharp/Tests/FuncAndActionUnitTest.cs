using Microsoft.VisualStudio.TestTools.UnitTesting;

using static ActionDelegate.Program;
using static FuncDelegate.Program;

namespace Tests
{
    [TestClass]
    public class FuncAndActionUnitTest
    {
        [TestMethod]
        public void WhenNotifying_ThenWritesCorrectMessageToConsole()
        {
            var expectedMessage = "Received message: 'build project'";
            TextWriter oldOut = Console.Out;

            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                SendNotification();

                var actualConsoleOutput = stringWriter.ToString().Trim();

                Assert.AreEqual(expectedMessage, actualConsoleOutput);
            }

            Console.SetOut(oldOut);
        }

        [TestMethod]
        public void WhenNotifying_ThenReceiveResult()
        {
            var expectedMessage = "building";

            var result = GetNotification();

            Assert.AreEqual(expectedMessage, result);
        }
    }
}