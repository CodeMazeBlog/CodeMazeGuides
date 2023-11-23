using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod]
        public void Given_ActionDelegateSample_When_InvokeMethod_Then_EnsureMessagePrinted()
        {
            // Arrange
            string expectedMessage = "Hello, invoking the delegate!";
            string? actualMessage = null;

            // Act
            Action<string> testPrintMessage = message =>
            {
                actualMessage = message;
            };

            testPrintMessage("Hello, invoking the delegate!");

            // Invoke the method being tested
            Program.ActionDelegateSample();

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void Given_FuncDelegateSample_When_InvokeMethod_Then_EnsureCorrectAreaCalculated()
        {
            // Arrange
            double radius = 20;
            double expectedArea = 3.12 * radius * radius;
            double actualArea = 0;

            // Act
            Func<double, double> testCalArea = r =>
            {
                return 3.12 * r * r;
            };

            actualArea = testCalArea(20);

            // Invoke the method being tested
            Program.FuncDelegateSample();

            // Assert
            Assert.AreEqual(expectedArea, actualArea);
        }
    }
}