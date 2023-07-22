using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UseMoqToReturnPassedInValue;

namespace Tests
{
    [TestClass]
    public class UseMoqToReturnPassedInValueTest
    {
        [TestMethod]
        public void GivenMockSetupToReturnHello_WhenCallingMock_ThenHelloReturned()
        {
            var mockPrinter = new Mock<IPrinter>();
            mockPrinter.Setup(iPrinter => iPrinter.Print(It.IsAny<string>())).Returns("Hello");
            IPrinter printer = mockPrinter.Object;

            string result1 = printer.Print("Hello");
            string result2 = printer.Print("Hola");

            Assert.AreEqual("Hello", result1);
            Assert.AreEqual("Hello", result2);
        }
        
        [TestMethod]
        public void GivenMockSetupToReturnPassedInValue_WhenCallingMock_ThenValueReturned()
        {
            var mockTranslator = new Mock<IPrinter>();
            mockTranslator.Setup(iTranslator => iTranslator.Print(It.IsAny<string>())).Returns((string input) => { return input; });
            IPrinter printer = mockTranslator.Object;

            string result1 = printer.Print("Hello");
            string result2 = printer.Print("Hola");

            Assert.AreEqual("Hello", result1);
            Assert.AreEqual("Hola", result2);
        }

        [TestMethod]
        public void GivenTwoDifferentInputs_WhenPrintingAll_ThenCorrectCountReturned()
        {
            var mockTranslator = new Mock<IPrinter>();
            mockTranslator.Setup(iTranslator => iTranslator.Print(It.IsAny<string>())).Returns((string input) => { return input; });
            IPrinter printer = mockTranslator.Object;
            var printerQueue = new PrinterQueue(printer);

            var characterCountPrinted = printerQueue.PrintAll(new[] { "Hello", "Hola" });

            Assert.AreEqual("HelloHola".Length, characterCountPrinted);
        }
    }
}