using ActionDelegate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Test
{
    [TestClass]
    public class ActionDelegateTest
    {
        [TestMethod]
        public void WhenCurrentYearAndCurrentAgeIsSubmitted_ThenReturnBirthYear()
        {
            // Arrange
            Action<int, int> BirthYear = (currentYear, currentAge) =>
            {
                var birthYear = currentYear - currentAge;
                Console.WriteLine($"Your birth year is: {birthYear}");
            };

            var testCurrentYear = 2024;
            var testCurrentAge = 30;
            var expectedBirthYear = 1994;

            // Act
            var actualBirthYear = 0;
            BirthYear += (currentYear, currentAge) =>
            {
                actualBirthYear = currentYear - currentAge;
            };
            BirthYear(testCurrentYear, testCurrentAge);

            // Assert
            Assert.AreEqual(expectedBirthYear, actualBirthYear);
        }
    }
}