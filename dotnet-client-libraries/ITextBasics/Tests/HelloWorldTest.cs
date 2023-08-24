using ITextBasics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class HelloWorldTest
    {
        [TestMethod]
        public void GivenBasicPdfCommand_WhenRunning_ThenExpectCreatedFile()
        {
            var runner = new PdfRunnerTest();
            runner.DoTest(HelloWorld.CreateBasicPDF);
        }

        [TestMethod]
        public void GivenAdvancedHeaderPDFCommand_WhenRunning_ThenExpectCreatedFile()
        {
            var runner = new PdfRunnerTest();
            runner.DoTest(HelloWorld.CreateAdvancedHeaderPDF);
        }

        [TestMethod]
        public void GivenAdvancedMoreParagraphsPDFCommand_WhenRunning_ThenExpectCreatedFile()
        {
            var runner = new PdfRunnerTest();
            runner.DoTest(HelloWorld.CreateAdvancedMoreParagraphsPDF);
        }

        [TestMethod]
        public void GivenCreatePDFWithImageCommand_WhenRunning_ThenExpectCreatedFile()
        {
            var runner = new PdfRunnerTest();
            runner.DoTest(HelloWorld.CreatePDFWithImage);
        }
    }
}
