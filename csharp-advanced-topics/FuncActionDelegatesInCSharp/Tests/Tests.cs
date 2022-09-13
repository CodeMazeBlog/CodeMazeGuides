using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class FuncActionDelegatesInCSharpUnitTest
    {

        static void DisplayCodeMazeMessage(string message)
        {
            Console.WriteLine(message);
        }

        static string GetCodeMazeMessage()
        {
            return ("CodeMaze is best source of C# func delegate info online.");
        }

        [TestMethod]
        public void whenMessageSent_FuncDelegateExecutesTheReferencedMethod()
        {
            Func<string> funcmessage = GetCodeMazeMessage;

            var result = funcmessage.Invoke();
            Assert.AreEqual("CodeMaze is best source of C# func delegate info online.", result);
        }
    }
}
