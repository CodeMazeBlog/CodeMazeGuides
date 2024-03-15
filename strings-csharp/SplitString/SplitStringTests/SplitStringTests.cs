using SplitString;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SplitStringTests
{
    [TestClass]
    public class SplitStringTests
    {
        [TestMethod]
        public void WhenSplittingAStringByMultipleCharacters_ThenReturnArrayOfSubstrings()
        {
            // Arrange
            string input = "hello,code;maze";
            char[] separators = { ',', ';' };
            string[] expectedOutput = { "hello", "code", "maze"};

            // Act
            string[] result = Program.SplitStringUsingCharacterArray(input, separators);

            // Assert
            CollectionAssert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        public void WhenSplittingAStringByMultipleCharactersWithSplitStringOptions_ThenReturnArrayOfSubstrings()
        {
            // Arrange
            string input = "Hello, world! How are you today?";
            char[] separators = { ' ', ',', '!' };
            string[] expectedOutput = { "Hello", "world", "How", "are", "you", "today?" };

            // Act
            string[] result = Program.SplitStringUsingCharacterArrayWithoptions(input, separators);

            // Assert
            CollectionAssert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        public void WhenSplittingAStringByMultipleCharactersWithCount_ThenReturnArrayOfSubstrings()
        {
            // Arrange
            string input = "apple,banana,orange,grape";
            char[] separators = { ',' };
            int count = 2;
            string[] expectedOutput = { "apple", "banana,orange,grape" };

            // Act
            string[] result = Program.SplitStringUsingCharacterArrayUsingCount(input, separators, count);

            // Assert
            CollectionAssert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        public void WhenSplittingAStringByMultipleCharactersWithCountAndOptions_ThenReturnArrayOfSubstrings()
        {
            // Arrange
            string input = " apple , banana , pear, mango ";
            char[] separators = { ',' };
            int count = 2;
            string[] expectedOutput = { "apple", "banana , pear, mango" };

            // Act
            string[] result = Program.SplitStringUsingCharacterArrayWithoptionsUsingCount(input, separators, count);

            // Assert
            CollectionAssert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        public void WhenSplittingAStringByStringArrayWithOptions_ThenReturnArrayOfSubstrings()
        {
            // Arrange
            string input = "apple,banana,,pear, ";
            string[] separators = { ",", " " };
            string[] expectedOutput = { "apple", "banana", "", "pear", "", "" };

            // Act
            string[] result = Program.SplitStringUsingStringArrayWithoptions(input, separators);

            // Assert
            CollectionAssert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        public void WhenSplittingAStringByStringArraWithCountAndOptions_ThenReturnArrayOfSubstrings()
        {
            // Arrange
            string input = "apple,banana, ,pear, ";
            string[] separators = { "," };
            int count = 3;
            string[] expectedOutput = { "apple", "banana", " ,pear, " };

            // Act
            string[] result = Program.SplitStringUsingStringArrayWithoptionsUsingCount(input, separators, count);

            // Assert
            CollectionAssert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        public void WhenSplittingAStringIntoNewLine_ThenReturnArrayOfSubstrings()
        {
            // Arrange
            string input = "Line 1\nLine 2\nLine 3\nLine 4\nLine 5";
            string[] separators = { Environment.NewLine };
            int expectedOutputLength = 5;

            // Act
            string[] result = Program.SplitStringIntoNewLines(input, separators);

            // Assert
            Assert.AreEqual(expectedOutputLength, result.Length);
        }
    }
}