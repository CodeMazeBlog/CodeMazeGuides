using NSubstitute;
using ActionAndFuncDelegatesInCSharp;

namespace Tests
{
    [TestFixture]
    public class FileHandlerUnitTest
    {
        private IConsole _console;
        private IFileReceiver _fileReceiver;
        private FileHandler _fileHandler;

        [SetUp]
        public void Setup()
        {
            _console = Substitute.For<IConsole>();
            _fileReceiver = Substitute.For<IFileReceiver>();
            _fileHandler = new(_fileReceiver, _console);
        }

        [Test]
        public void WhenInstantiated_ThenActionAndFuncArePopulated()
        {
            Assert.That(_fileReceiver.FileReceivedAction, Is.Not.Null);
            Assert.That(_fileReceiver.FileReceivedFunc, Is.Not.Null);
        }

        [TestCase(TestName = "Failure")]
        [TestCase(true, TestName = "Success")]
        public void WhenProcessingFileContent_ThenCorrectOutput(bool success = false)
        {
            int value = 0;
            Func<int, bool> func = v =>
            {
                value = v;
                return(success);
            };

            _fileHandler.Process("123", func);

            Assert.That(value, Is.EqualTo(123));
            _console.Received(1).Output(success ? "Success!" : "Failure!");
        }

        [Test]
        public void WhenProcessingFileContentInAction_ThenCorrectOutput()
        {
            _fileReceiver.FileReceivedAction("123");

            _console.Received(1).Output("Processing file content in action method: '123'");
        }

        [Test]
        public void WhenProcessingFileContentInFunc_ThenCorrectOutput()
        {
            bool result = _fileReceiver.FileReceivedFunc("123");

            _console.Received(1).Output("Processing file content in func method: '123'");
            Assert.That(result);
            result = _fileReceiver.FileReceivedFunc("123");
            _console.Received(2).Output("Processing file content in func method: '123'");
            Assert.That(!result);
        }
    }
}