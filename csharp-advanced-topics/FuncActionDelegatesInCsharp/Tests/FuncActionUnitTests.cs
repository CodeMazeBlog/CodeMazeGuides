using System.IO;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static FuncActionDelegatesInCsharp.Program;

namespace Tests
{
    [TestClass]
    public class FuncActionUnitTests : IDisposable
    {
        private readonly StringWriter output = new StringWriter();

        public FuncActionUnitTests()
        {
            Console.SetOut(output);
        }

        public void Dispose()
        {
            output.Dispose();
            GC.SuppressFinalize(this);
        }

        public string[] PrintedOutputToArray()
        {
            var printedString = output.ToString();
            return printedString.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }

        [TestMethod]
        public void WhenRunningDelegateExample_TwoDelegateMethodsShouldBeInvoked()
        {
            var text = "example text";
            var path = "C:\\";
            RunDelegateExample(text, path);
            var printedOutput = PrintedOutputToArray();

            Assert.AreEqual(printedOutput.Length, 2);
            Assert.AreEqual(printedOutput[0], GetSaveAsText(text, "pdf", path));
            Assert.AreEqual(printedOutput[1], GetSaveAsText(text, "docx", path));
        }

        [TestMethod]
        public void WhenRunningActionExample_SaveAsDocxActionShouldBeInvoked()
        {
            var text = "example text";
            var path = "C:\\";
            RunActionExample(text, path);
            var printedOutput = PrintedOutputToArray();

            Assert.AreEqual(printedOutput.Length, 1);
            Assert.AreEqual(printedOutput[0], GetSaveAsText(text, "docx", path));
        }

        [TestMethod]
        public void WhenRunningFuncExample_SaveAsDocxActionShouldBeInvoked()
        {
            var text = "example text";
            var path = "C:\\";
            var isSuccessful = RunFuncExample(text, path);
            var printedOutput = PrintedOutputToArray();

            Assert.AreEqual(printedOutput.Length, 1);
            Assert.AreEqual(printedOutput[0], GetSaveAsText(text, "docx", path));
            Assert.IsTrue(isSuccessful);
        }
    }
}
