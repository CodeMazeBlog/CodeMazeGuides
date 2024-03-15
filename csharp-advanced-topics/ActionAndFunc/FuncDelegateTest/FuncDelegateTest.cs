using FuncDelegate;
using Microsoft.VisualStudio.TestPlatform.TestHost;
namespace FuncDelegateTest
{
    [TestClass]
    public class FuncDelegateTest
    {
        [TestMethod]
        public void GivenCurrentYearAndCurrentAgeIsAdded_Then_ReturnBirthYear()
        {
            //Arrange
            int currentYear = 2024;
            int currentAge = 30;
            int birthYear = 1994;

            //Act
            var result = FuncDelegate.Program.BirthYear(currentYear, currentAge);
            //Assert
            Assert.AreEqual(birthYear, result);
        }
    }
}