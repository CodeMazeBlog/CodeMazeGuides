using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class ConvertString2CharArrayUnitTests
    {
        [TestMethod]
        public void GivenString_WhenConvertedByToCharArray_ThenReturnsExpectedCharArray()
        {
            // Arrange
            var str = "Code Maze";

            // Act
            var charArray = str.ToCharArray();

            // Assert
            Assert.AreEqual('C', charArray[0]);
            Assert.AreEqual('o', charArray[1]);
            Assert.AreEqual('d', charArray[2]);
            Assert.AreEqual('e', charArray[3]);
            Assert.AreEqual(' ', charArray[4]);
            Assert.AreEqual('M', charArray[5]);
            Assert.AreEqual('a', charArray[6]);
            Assert.AreEqual('z', charArray[7]);
            Assert.AreEqual('e', charArray[8]);
        }

        [TestMethod]
        public void GivenString_WhenConvertedByForLoop_ThenReturnsExpectedCharArray()
        {
            // Arrange
            var str = "Code Maze";
            var expectedCharArray = new char[] { 'C', 'o', 'd', 'e', ' ', 'M', 'a', 'z', 'e' };

            // Act
            var charArray = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                charArray[i] = str[i];
            }

            // Assert
            Assert.AreEqual(expectedCharArray, charArray);
        }

        [TestMethod]
        public void GivenString_WhenConvertedByLinqMethod_ThenReturnsExpectedCharArray()
        {
            // Arrange
            var str = "Code Maze";
            var expectedCharArray = new char[] { 'C', 'o', 'd', 'e', ' ', 'M', 'a', 'z', 'e' };

            // Act
            var charArrays = str.Select(c => new char[] { c }).ToArray();
            var charArray = charArrays[0];

            // Assert
            Assert.AreEqual(expectedCharArray, charArray);
        }

        [TestMethod]
        public void GivenString_WhenConvertedByReadOnlySpan_ThenReturnsExpectedString()
        {
            // Arrange
            var str = "Code Maze";
            var expectedString = "Code Maze";

            // Act
            ReadOnlySpan<char> charSpan = str;
            var convertedString = charSpan.ToString();

            // Assert
            Assert.AreEqual(expectedString, convertedString);
        }

        [TestMethod]
        public void GivenString_WhenConvertedByUnsafeCode_ThenReturnsExpectedCharArray()
        {
            // Arrange
            var str = "Code Maze";
            var expectedCharArray = new char[] { 'C', 'o', 'd', 'e', ' ', 'M', 'a', 'z', 'e' };

            // Act
            unsafe
            {
                char[] charArray3;

                fixed (char* p = str)
                {
                    charArray3 = new char[str.Length];
                    for (int i = 0; i < str.Length; i++)
                    {
                        charArray3[i] = p[i];
                    }
                }

                // Assert
                Assert.AreEqual(expectedCharArray, charArray3);
            }
        }

        [TestMethod]
        public void GivenCharArray_WhenReversed_ThenReturnsExpectedString()
        {
            // Arrange
            var charArray = new char[] { 'H', 'e', 'l', 'l', 'o', ',', ' ', 'C', '#' };
            var expectedString = "#C ,olloH";

            // Act
            Array.Reverse(charArray);
            var reversedString = new string(charArray);

            // Assert
            Assert.AreEqual(expectedString, reversedString);
        }

    [TestMethod]
        public void GivenCharArray_WhenSorted_ThenReturnsExpectedString()
        {
            // Arrange
            var charArray = new char[] { 'H', 'e', 'l', 'l', 'o', ',', ' ', 'C', '#' };
            var expectedString = "#, C, H, e, l, l, o, X";

            // Act
            Array.Sort(charArray);
            var sortedString = new string(charArray);

            // Assert
            Assert.AreEqual(expectedString, sortedString);
        }

        [TestMethod]
        public void GivenCharArray_WhenUppercased_ThenReturnsExpectedString()
        {
            // Arrange
            var charArray = new char[] { 'H', 'e', 'l', 'l', 'o', ',', ' ', 'C', '#' };
            var expectedString = "HELLO, C#";

            // Act
            for (int i = 0; i < charArray.Length; i++)
            {
                charArray[i] = char.ToUpper(charArray[i]);
            }
            var uppercasedString = new string(charArray);

            // Assert
            Assert.AreEqual(expectedString, uppercasedString);
        }

        [TestMethod]
        public void GivenCharArray_WhenReplaced_ThenReturnsExpectedString()
        {
            // Arrange
            var charArray = new char[] { 'H', 'e', 'l', 'l', 'o', ',', ' ', 'C', '#' };
            var expectedString = "HELLO, C++";

            // Act
            var modifiedString = new string(charArray);
            modifiedString = modifiedString.Replace("C#", "C++");

            // Assert
            Assert.AreEqual(expectedString, modifiedString);
        }
    }
}
