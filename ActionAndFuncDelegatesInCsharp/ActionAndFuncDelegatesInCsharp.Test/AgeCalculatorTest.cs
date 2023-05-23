using Microsoft.VisualStudio.TestPlatform.TestHost;
using ActionAndFuncDelegatesInCsharp;
namespace ActionAndFuncDelegatesInCsharp.Test
{
    public class AgeCalculatorTest
    {
        private StringWriter stringWriter;
        private TextWriter originalOutput;

        [SetUp]
        public void Setup()
        {
            stringWriter = new StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(stringWriter);
        }

        [TearDown]
        public void Cleanup()
        {
            Console.SetOut(originalOutput);
            stringWriter.Dispose();
        }

        [Test]
        public void CalculateAge_ValidBirthYear_ReturnsCorrectAge()
        {
            // Arrange
            int expectedAge = DateTime.Now.Year - 2000;

            // Act
            int actualAge = AgeCalculator.ageCalculator(2000);

            // Assert
            Assert.AreEqual(expectedAge, actualAge);
        }

    }
}