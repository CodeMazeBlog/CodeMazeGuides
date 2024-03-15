using ActionDelegate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Test
{
    [TestClass]
    public class ActionDelegateTest
    {
        [TestMethod]
        public void GivenCurrentYearAndCurrentAgeIsAdded_Then_ReturnBirthYear()
        {
            // Arrange
            Action<int, int> BirthYear = (currentYear, currentAge) =>
            {
                int birthYear = currentYear - currentAge;
                Console.WriteLine($"Your birth year is: {birthYear}");
            };

            int testCurrentYear = 2024;
            int testCurrentAge = 30;
            int expectedBirthYear = 1994;

            // Act
            int actualBirthYear = 0;
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