using FuncDelegate;
using Microsoft.VisualStudio.TestPlatform.TestHost;
namespace FuncDelegateTest
{
    [TestClass]
    public class FuncDelegateTest
    {
        [TestMethod]
        public void WhenCurrentYearAndCurrentAgeIsSubmitted_ThenReturnBirthYear()
        {
            //Arrange
            var currentYear = 2024;
            var currentAge = 30;
            var birthYear = 1994;

            //Act
            var result = FuncDelegate.Program.BirthYear(currentYear, currentAge);
            //Assert
            Assert.AreEqual(birthYear, result);
        }
    }
}