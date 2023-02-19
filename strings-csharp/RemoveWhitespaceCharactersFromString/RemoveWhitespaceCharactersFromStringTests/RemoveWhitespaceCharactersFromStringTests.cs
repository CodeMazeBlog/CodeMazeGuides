using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace RemoveWhitespaceCharactersFromStringTests
{
    [TestClass]
    public class RemoveWhitespaceCharactersFromStringTests

    {
        [TestMethod]
        public void GivenStringWithWhitespaces_WhenUsingRegex_ThenResultStringDoesntContainWhitespace()
        {
            string source = " \t hello worl d \r\n ";
            
            string result = Regex.Replace(source, @"\s+", String.Empty);
            
            Assert.AreEqual("helloworld", result);
        }

        [TestMethod]
        public void GivenStringWithWhitespaces_WhenUsingLinq_ThenResultStringDoesntContainWhitespace()
        {
            string source = " \t hello worl d";

            string result = string.Concat(source.Where(c => !char.IsWhiteSpace(c)));

            Assert.AreEqual("helloworld", result);
        }
        
        [TestMethod]
        public void GivenStringWithWhitespaces_WhenUsingStringReplace_ThenResultStringDoesntContainWhitespace()
        {
            string source = " hello worl d";

            string result = source.Replace(" ", string.Empty);

            Assert.AreEqual("helloworld", result);
        }
        [TestMethod]
        public void GivenStringWithTab_WhenUsingStringReplace_ThenResultStringContainsTab()
        {
            string source = "\t hello";

            string result = source.Replace(" ", string.Empty);

            Assert.AreEqual("\thello", result);
        }
        [TestMethod]
        public void GivenStringWithWhitespaces_WhenUsingStringTrim_ThenResultStringDoesntContainLeadingOrTrailingWhitespace()
        {
            string source = "  \t John Doe ";

            string result = source.Trim();

            Assert.AreEqual("John Doe", result);
        }
    }
}