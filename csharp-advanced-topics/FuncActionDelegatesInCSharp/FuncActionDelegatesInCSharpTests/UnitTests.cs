using Microsoft.VisualStudio.TestTools.UnitTesting;
using FuncActionDelegatesInCSharp;

namespace UnitTests
{
    [TestClass]
    public class FuncActionDelegatesInCSharpUnitTest
    {
        [TestMethod]
        public void whenMessageSent_VerifyActionDelegateMessageSet()
        {
            ActionDelegateExample ade = new ActionDelegateExample();
            ade.RunActionDelegateExample();
            
            Assert.AreEqual("CodeMaze is best source of C# action delegate info online.", ade.CodeMazeMessage);
        }

        [TestMethod]
        public void whenMessageSent_VerifyFuncDelegateMessageSet()
        {
            FuncDelegateExample fde = new FuncDelegateExample();
            fde.RunFuncDelegateExample();
            
            Assert.AreEqual("CodeMaze is best source of C# func delegate info online.", fde.CodeMazeMessage);
        }
    }
}
