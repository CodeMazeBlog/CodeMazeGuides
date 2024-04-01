using DetectKeyPressInCSharp;
using Moq;
using NUnit.Framework;

namespace Tests
{ 
    [TestFixture]
    public class ConsoleAppTests
    {
        private Mock<IConsoleService> _mockConsoleService;
        private ConsoleApp _app;

        [SetUp]
        public void Setup()
        {
            _mockConsoleService = new Mock<IConsoleService>();
            _app = new ConsoleApp(_mockConsoleService.Object);
        }

        [Test]
        public void WhenConsoleReadkey_ThenPrintCorrectMessage()
        {
            _mockConsoleService.SetupSequence(m => m.ReadKey(false))
                .Returns(new ConsoleKeyInfo('A', ConsoleKey.A, false, false, false))
                .Returns(new ConsoleKeyInfo('B', ConsoleKey.B, false, false, false));

            _app.ReadKeyUse();

            _mockConsoleService.Verify(m => m.WriteLine("Press any key to continue..."), Times.Exactly(2));
            _mockConsoleService.Verify(m => m.WriteLine("\nYou pressed: A"), Times.Once());
            _mockConsoleService.Verify(m => m.WriteLine("\nYou pressed: B"), Times.Once());
            _mockConsoleService.Verify(m => m.WriteLine("Process stopped"), Times.Once());
        }

        [Test]
        public void WhenXIsPressed_ThenApplicationShouldStop()
        {
            _mockConsoleService.SetupSequence(m => m.KeyAvailable)
                .Returns(false)
                .Returns(true);
            _mockConsoleService.Setup(m => m.ReadKey(true))
                .Returns(new ConsoleKeyInfo('X', ConsoleKey.X, false, false, false));

            _app.KeyAvailableUse();

            _mockConsoleService.Verify(m => m.WriteLine("Press 'x' to stop!"), Times.AtLeastOnce());
            _mockConsoleService.Verify(m => m.WriteLine("Process stopped"), Times.Once());
        }
    }
}
