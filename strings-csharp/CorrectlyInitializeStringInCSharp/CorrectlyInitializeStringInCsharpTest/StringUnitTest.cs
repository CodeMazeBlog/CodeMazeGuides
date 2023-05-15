using CorrectlyInitializeStringInCSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CorrectlyInitializeStringInCsharpTest
{
    [TestClass]
    public class StringUnitTest
    {
        [TestMethod]
        public void GivenMyString1_WhenExecuted_ThenReturnsHelloWorld()
        {
            // Arrange
            string expected = "Hello, World!";

            // Act
            string actual = StringExamples.MyString1();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenMyString2_WhenExecuted_ThenReturnsHelloNewlineWorld()
        {
            // Arrange
            string expected = "Hello,\nWorld!";

            // Act
            string actual = StringExamples.MyString2();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenFirstNameAndLastName_WhenFullNameCalled_ThenReturnsFullName()
        {
            // Arrange
            string firstName = "John";
            string lastName = "Doe";
            string expected = "John Doe";

            // Act
            string actual = StringExamples.FullName(firstName, lastName);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenEmptyPath_WhenPathCalled_ThenReturnsPath()
        {
            // Arrange
            string expected = @"C:\Users\Codemaze\Documents";

            // Act
            string actual = StringExamples.Path();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenMultiLineString_WhenExecuted_ThenReturnsStringWithNewlines()
        {
            // Arrange            
            string expected = @"This is
            a multi-line
            string.";
            // Act
            string actual = StringExamples.MultiLineString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenEmptyString_WhenExecuted_ThenReturnsEmptyString()
        {
            // Arrange
            string expected = string.Empty;

            // Act
            string actual = StringExamples.EmptyString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenNullString_WhenExecuted_ThenReturnsNull()
        {
            // Arrange

            // Act
            string? actual = StringExamples.NullString();

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GivenDefaultString_WhenExecuted_ThenReturnsNull()
        {
            // Arrange

            // Act
            string? actual = StringExamples.DefaultString();

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GivenStringBuilderString_WhenExecuted_ThenReturnsHelloWorld()
        {
            // Arrange
            string expected = "Hello World";

            // Act
            string actual = StringExamples.StringBuilderString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenTwoNumbers_WhenSumStringCalled_ThenReturnsStringWithSum()
        {
            // Arrange
            int a = 5;
            int b = 10;
            string expected = "The sum of 5 and 10 is 15";

            // Act
            string actual = StringExamples.SumString(a, b);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenAsteriskCount_WhenAsteriskStringCalled_ThenReturnsStringWithAsterisks()
        {
            // Arrange
            int count = 10;
            string expected = "**********";

            // Act
            string actual = StringExamples.AsteriskString(count);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}