using Microsoft.VisualStudio.TestPlatform.TestHost;
using ActionAndFuncDelegatesInCsharp;
namespace ActionAndFuncDelegatesInCsharp.Test
{
    public class AgeCalculatorUnitTest
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
        public void GivenYearofBirth_WhenYearIs2000_ThenAgeIs23()
        {
            // Arrange
            int expectedAge = 23;

            // Act
            int actualAge = AgeCalculatorClass.AgeCalculator(2000);

            // Assert
            Assert.AreEqual(expectedAge, actualAge);
        }

        [Test]
        public void GivenYearofBirth_WhenYearIs2010_ThenAgeIs13()
        {
            // Arrange
            int expectedAge = 13;

            // Act
            int actualAge = AgeCalculatorClass.AgeCalculator(2010);

            // Assert
            Assert.AreEqual(expectedAge, actualAge);
        }
    }
}