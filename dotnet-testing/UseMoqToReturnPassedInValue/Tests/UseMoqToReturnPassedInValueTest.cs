using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UseMoqToReturnPassedInValue;

namespace Tests
{
    [TestClass]
    public class UseMoqToReturnPassedInValueTest
    {
        private const string Hello = "Hello";
        private const string Hola = "Hola";
        
        [TestMethod]
        public void GivenMockSetupToReturnHello_WhenCallingMock_ThenHelloReturned()
        {
            var mockPrinter = new Mock<IPrinter>();
            mockPrinter.Setup(iPrinter => iPrinter.Print(It.IsAny<string>())).Returns(Hello);
            var printer = mockPrinter.Object;

            var result1 = printer.Print(Hello);
            var result2 = printer.Print(Hola);

            Assert.AreEqual(Hello, result1);
            Assert.AreEqual(Hello, result2);
        }
        
        [TestMethod]
        public void GivenMockSetupToReturnPassedInValue_WhenCallingMock_ThenValueReturned()
        {
            var mockTranslator = new Mock<IPrinter>();
            mockTranslator.Setup(iTranslator => iTranslator.Print(It.IsAny<string>()))
                .Returns((string input) => { return input; });
            var printer = mockTranslator.Object;

            var result1 = printer.Print(Hello);
            var result2 = printer.Print(Hola);

            Assert.AreEqual(Hello, result1);
            Assert.AreEqual(Hola, result2);
        }

        [TestMethod]
        public void GivenTwoDifferentInputs_WhenPrintingAll_ThenCorrectCountReturned()
        {
            var mockTranslator = new Mock<IPrinter>();
            mockTranslator.Setup(iTranslator => iTranslator.Print(It.IsAny<string>()))
                .Returns((string input) => { return input; });
            var printer = mockTranslator.Object;
            var printerQueue = new PrinterQueue(printer);
            var sampleData = new[] { Hello, Hola };

            var characterCountPrinted = printerQueue.PrintAll(sampleData);

            var expectedCount = sampleData[0].Length + sampleData[1].Length;
            Assert.AreEqual(expectedCount, characterCountPrinted);
        }
    }
}