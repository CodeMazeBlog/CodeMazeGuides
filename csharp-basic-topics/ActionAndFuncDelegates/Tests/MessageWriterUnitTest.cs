using ActionAndFuncDelegates;

namespace Tests
{
    public class MessageWriterUnitTest
    {
        private readonly string messagePrefix = "testPrefix";
        private MessageWriter sut;
        private readonly StringWriter testOutput = new();

        [SetUp]
        public void Setup()
        {
            sut = new MessageWriter(messagePrefix, testOutput);
        }

        [Test]
        public void WhenReportElementFoundCalled_ThenOutputStartsWithMessagePrefix()
        {
            const int x = 0;
            sut.ReportElementFound(x);

            Assert.That(testOutput.ToString(), Does.StartWith(messagePrefix));
        }

        [Test]
        public void WhenReportNotElementFoundCalled_ThenOutputStartsWithMessagePrefix()
        {
            const int x = 0;
            sut.ReportElementNotFound(x);

            Assert.That(testOutput.ToString(), Does.StartWith(messagePrefix));
        }
    }
}