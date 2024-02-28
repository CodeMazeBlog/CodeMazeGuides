using DetectKeyPressInCSharp;
using Moq;
using NUnit.Framework;
using System.Runtime;
using System.Reflection;

namespace Tests
{ 
    [TestFixture]
    public class ConsoleAppTests
    {
        private Mock<IConsoleService> mockConsoleService;
        private ConsoleApp app;

        [SetUp]
        public void Setup()
        {
            mockConsoleService = new Mock<IConsoleService>();
            app = new ConsoleApp(mockConsoleService.Object);
        }

        [Test]
        public void ReadKeyUse_ShouldPrintCorrectMessages()
        {
            mockConsoleService.SetupSequence(m => m.ReadKey(false))
                .Returns(new ConsoleKeyInfo('A', ConsoleKey.A, false, false, false))
                .Returns(new ConsoleKeyInfo('B', ConsoleKey.B, false, false, false));

            app.ReadKeyUse();

            mockConsoleService.Verify(m => m.WriteLine("Press any key to continue..."), Times.Exactly(2));
            mockConsoleService.Verify(m => m.WriteLine("\nYou pressed: A"), Times.Once());
            mockConsoleService.Verify(m => m.WriteLine("\nYou pressed: B"), Times.Once());
            mockConsoleService.Verify(m => m.WriteLine("Process stopped"), Times.Once());
        }

        [Test]
        public void KeyAvailableUse_ShouldStopWhenXIsPressed()
        {
            mockConsoleService.SetupSequence(m => m.KeyAvailable)
                .Returns(false)
                .Returns(true);
            mockConsoleService.Setup(m => m.ReadKey(true))
                .Returns(new ConsoleKeyInfo('X', ConsoleKey.X, false, false, false));

            app.KeyAvailableUse();

            mockConsoleService.Verify(m => m.WriteLine("Press 'x' to stop!"), Times.AtLeastOnce());
            mockConsoleService.Verify(m => m.WriteLine("Process stopped"), Times.Once());
        }
    }
}
