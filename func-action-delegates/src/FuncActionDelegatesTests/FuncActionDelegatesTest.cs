
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FuncActionDelegatesTests
{
    [TestClass]
    public class FuncActionDelegatesTest
    {
        [TestMethod]
        public void whenCallFuncDelegate()
        {

            Func<string, string, string> funcDelegate = FuncDelegate.Program.Append;
            string fullName = funcDelegate("Code", "Maze");
            Assert.AreEqual(fullName, "CodeMaze");
            
        }

        [TestMethod]
        public void whenCallActionDelegate()
        {
            Assert.AreEqual("CodeMaze", "CodeMaze");
        }
    }
}