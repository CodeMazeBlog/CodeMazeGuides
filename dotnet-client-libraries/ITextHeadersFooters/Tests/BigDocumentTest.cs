using ITextHeadersFooters;

namespace Tests
{
    [TestClass]
    public class BigDocumentTest
    {
        [TestMethod]
        public void GivenCreateBasicDocumentCommand_WhenRunning_ThenExpectCreatedFile()
        {
            var runner = new PdfRunnerTest();
            runner.DoTest(BigDocument.CreateBasicDocument);
        }

        [TestMethod]
        public void GivenCreateBasicDocumentWithBigMarginsCommand_WhenRunning_ThenExpectCreatedFile()
        {
            var runner = new PdfRunnerTest();
            runner.DoTest(BigDocument.CreateBasicDocumentWithBigMargins);
        }

        [TestMethod]
        public void GivenAddTextAfterPageWasGeneratedCommand_WhenRunning_ThenExpectCreatedFile()
        {
            var runner = new PdfRunnerTest();
            runner.DoTest(BigDocument.AddTextAfterPageWasGenerated);
        }

        [TestMethod]
        public void GivenUsageOfShowTextAlignedMethodCommand_WhenRunning_ThenExpectCreatedFile()
        {
            var runner = new PdfRunnerTest();
            runner.DoTest(BigDocument.UsageOfShowTextAlignedMethod);
        }

        [TestMethod]
        public void GivenClassic_XofY_FooterCommand_WhenRunning_ThenExpectCreatedFile()
        {
            var runner = new PdfRunnerTest();
            runner.DoTest(BigDocument.Classic_XofY_Footer);
        }

        [TestMethod]
        public void GivenPageNumberInHeaderDateInFooterCommand_WhenRunning_ThenExpectCreatedFile()
        {
            var runner = new PdfRunnerTest();
            runner.DoTest(BigDocument.PageNumberInHeaderDateInFooter);
        }

        [TestMethod]
        public void GivenDrawLineCommand_WhenRunning_ThenExpectCreatedFile()
        {
            var runner = new PdfRunnerTest();
            runner.DoTest(BigDocument.DrawLine);
        }

        [TestMethod]
        public void GivenDifferentLeftAndRightPageCommand_WhenRunning_ThenExpectCreatedFile()
        {
            var runner = new PdfRunnerTest();
            runner.DoTest(BigDocument.DifferentLeftAndRightPage);
        }
    }
}
