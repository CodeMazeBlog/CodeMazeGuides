using Microsoft.VisualStudio.TestTools.UnitTesting;
using ActionAndFuncExample;

namespace Tests
{
    [TestClass]
    public class ActionAndFuncExampleTest
    {
        [TestMethod]
        public void CountChars_Expected_Actual()
        {
            // Arrange
            double expected = 10;

            // Act
            int actual = CountChars.CountCharsFunc("test count");

            // Assert
            Assert.AreEqual(expected, actual, 0, "The function returns wrong value");
        }

        [TestMethod]
        public void CountWords_Expected_Actual()
        {
            // Arrange
            double expected = 2;

            // Act
            int actual = CountChars.CountWordsFunc("test count");

            // Assert
            Assert.AreEqual(expected, actual, 0, "The function returns wrong value");
        }
    }
}