/* PLEASE add the `[assembly: InternalsVisibleTo("ActionAndFuncDelegatesUnitTest")]` ActionAndFuncDelegates project 
 * attribute to the  to allow the test project to access internal classes and methods of the ActionAndFuncDelegates project. */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ActionAndFuncDelegates;
namespace ActionAndFuncDelegatesUnitTest
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void TestIsEven_WhenEvenNumber_ReturnsTrue()
        {
            // Arrange
            int evenNumber = 4;

            // Act
            bool result = Program.IsEven(evenNumber);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestIsEven_WhenOddNumber_ReturnsFalse()
        {
            // Arrange
            int oddNumber = 3;

            // Act
            bool result = Program.IsEven(oddNumber);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestDoubleNumber()
        {
            // Arrange
            int number = 5;

            // Act
            Program.DoubleNumber(number);
        }
    }
}
