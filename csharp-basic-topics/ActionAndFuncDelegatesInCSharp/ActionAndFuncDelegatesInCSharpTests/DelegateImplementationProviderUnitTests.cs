using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;

namespace ActionAndFuncDelegatesInCSharpTests
{
    [TestClass]
    public class DelegateImplementationProviderUnitTests
    {
        Mock<IDateTimeProvider> _mockDateTimeProvider = new Mock<IDateTimeProvider>();
        Mock<IConsoleWrapper> _mockConsoleWrapper = new Mock<IConsoleWrapper>();
        DelegateImplementationProvider _target;

        [TestInitialize] 
        public void SetUp()
        {
            _target = new DelegateImplementationProvider(_mockDateTimeProvider.Object, _mockConsoleWrapper.Object);
        }
       
        [TestMethod]
        public void WhenExecutingFunc_ThenTheFuncMustReturnDataAsExpected()
        {
            // Arrange
            var expected = new DateTime(2023, 01, 23, 22, 41, 59);
            _mockDateTimeProvider.Setup(d=>d.GetDateTimeUTC()).Returns(expected);
            var printWithColor = _target.PrintWithColor;
            var msg = "Message from Func Unit Test";
            var expectedLogMessage = $"{expected} {msg}";
            var consoleColor = ConsoleColor.Yellow;

            // Act
            var actual = printWithColor(consoleColor, msg);
            // Assert
            Assert.AreEqual(expected, actual);
            _mockDateTimeProvider.Verify(d => d.GetDateTimeUTC(), Times.Once);
            _mockConsoleWrapper.Verify(c => c.WriteText(expectedLogMessage), Times.Once);
            _mockConsoleWrapper.Verify(c => c.SetColor(consoleColor), Times.Once);
        }

        [TestMethod]
        public void WhenExecutingAction_ThenTheActionMustRunWithAllExpectations()
        {
            // Arrange
            var currDateTime = new DateTime(2023, 01, 23, 23, 41, 59);
            _mockDateTimeProvider.Setup(d => d.GetDateTimeUTC()).Returns(currDateTime);
            var printWithColor = _target.PrintWithColor;
            var msg = "Message from Action Unit Test";
            var expectedLogMessage = $"{currDateTime} {msg}";
            var consoleColor = ConsoleColor.Magenta;
            // Act
            printWithColor(consoleColor, msg);
            // Assert
            _mockDateTimeProvider.Verify(d => d.GetDateTimeUTC(), Times.Once);
            _mockConsoleWrapper.Verify(c => c.WriteText(expectedLogMessage), Times.Once);
            _mockConsoleWrapper.Verify(c => c.SetColor(consoleColor), Times.Once);
        }
    }
}