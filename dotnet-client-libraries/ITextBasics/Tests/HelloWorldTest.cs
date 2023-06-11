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
            var helloWorld = new HelloWorld();
            var tmpFileName = Path.GetTempFileName();
            var runner = new PdfRunnerTest();
            runner.DoTest(tmpFileName, helloWorld.CreateBasicPDF);
        }

        [TestMethod]
        public void GivenAdvancedHeaderPDFCommand_WhenRunning_ThenExpectCreatedFile()
        {
            var helloWorld = new HelloWorld();
            var tmpFileName = Path.GetTempFileName();
            var runner = new PdfRunnerTest();
            runner.DoTest(tmpFileName, helloWorld.CreateAdvancedHeaderPDF);
        }

        [TestMethod]
        public void GivenAdvancedMoreParagraphsPDFCommand_WhenRunning_ThenExpectCreatedFile()
        {
            var helloWorld = new HelloWorld();
            var tmpFileName = Path.GetTempFileName();
            var runner = new PdfRunnerTest();
            runner.DoTest(tmpFileName, helloWorld.CreateAdvancedMoreParagraphsPDF);
        }

        [TestMethod]
        public void GivenCreatePDFWithImageCommand_WhenRunning_ThenExpectCreatedFile()
        {
            var helloWorld = new HelloWorld();
            var tmpFileName = Path.GetTempFileName();
            var runner = new PdfRunnerTest();
            runner.DoTest(tmpFileName, helloWorld.CreatePDFWithImage);
        }
    }
}
