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
            var expected = "Hello, World!";

            // Act
            var actual = StringExamples.MyString1();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenMyString2_WhenExecuted_ThenReturnsHelloNewlineWorld()
        {
            // Arrange
            var expected = "Hello,\nWorld!";

            // Act
            var actual = StringExamples.MyString2();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenFirstNameAndLastName_WhenFullNameCalled_ThenReturnsFullName()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";
            var expected = "John Doe";

            // Act
            var actual = StringExamples.FullName(firstName, lastName);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenEmptyPath_WhenPathCalled_ThenReturnsPath()
        {
            // Arrange
            var expected = @"C:\Users\Codemaze\Documents";

            // Act
            var actual = StringExamples.Path();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenMultiLineString_WhenExecuted_ThenReturnsStringWithNewlines()
        {
            // Arrange            
            var expected = @"This is
            a multi-line
            string.";
            // Act
            var actual = StringExamples.MultiLineString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenEmptyString_WhenExecuted_ThenReturnsEmptyString()
        {
            // Arrange
            var expected = string.Empty;

            // Act
            var actual = StringExamples.EmptyString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenNullString_WhenExecuted_ThenReturnsNull()
        {
            // Act
            var actual = StringExamples.NullString();

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GivenDefaultString_WhenExecuted_ThenReturnsNull()
        {
            // Act
            var actual = StringExamples.DefaultString();

            // Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GivenStringBuilderString_WhenExecuted_ThenReturnsHelloWorld()
        {
            // Arrange
            var expected = "Hello World";

            // Act
            var actual = StringExamples.StringBuilderString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenStringBuilderClearString_WhenExecuted_ThenClearsString()
        {
            // Arrange
            var expected = string.Empty;

            // Act
            var actual = StringExamples.StringBuilderClear();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenStringBuilderReplaceString_WhenExecuted_ThenReplaceString()
        {
            // Arrange
            var expected = "Hello Universe!";

            // Act
            var actual = StringExamples.StringBuilderReplace();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GivenStringBuilderInsertString_WhenExecuted_ThenInsertString()
        {
            // Arrange
            var expected = "Hello,  World!";
            // Act
            var actual = StringExamples.StringBuilderInsert();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GivenTwoNumbers_WhenSumStringCalled_ThenReturnsStringWithSum()
        {
            // Arrange
            var a = 5;
            var b = 10;
            var expected = "The sum of 5 and 10 is 15";

            // Act
            var actual = StringExamples.SumString(a, b);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenAsteriskCount_WhenAsteriskStringCalled_ThenReturnsStringWithAsterisks()
        {
            // Arrange
            var count = 10;
            var expected = "**********";

            // Act
            var actual = StringExamples.AsteriskString(count);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}