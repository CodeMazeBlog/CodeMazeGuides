using ITextBasics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BigDocumentTest
    {
        [TestMethod]
        public void GivenCreateCommand_WhenRunning_ThenExpectCreatedFile()
        {
            var runner = new PdfRunnerTest();
            runner.DoTest(BigDocument.Create);
        }
    }
}
