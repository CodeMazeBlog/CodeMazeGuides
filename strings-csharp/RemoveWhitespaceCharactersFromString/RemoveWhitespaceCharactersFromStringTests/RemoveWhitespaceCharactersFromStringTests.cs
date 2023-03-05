using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
            var source = " \t hello worl d";

            var result = string.Concat(source.Where(c => !char.IsWhiteSpace(c)));

            Assert.AreEqual("helloworld", result);
        }
        
        [TestMethod]
        public void GivenStringWithWhitespaces_WhenUsingStringReplace_ThenResultStringDoesntContainWhitespace()
        {
            var source = " hello worl d";

            var result = source.Replace(" ", string.Empty);

            Assert.AreEqual("helloworld", result);
        }
        [TestMethod]
        public void GivenStringWithTab_WhenUsingStringReplace_ThenResultStringContainsTab()
        {
            var source = "\t hello";

            var result = source.Replace(" ", string.Empty);

            Assert.AreEqual("\thello", result);
        }
        [TestMethod]
        public void GivenStringWithWhitespaces_WhenUsingStringTrim_ThenResultStringDoesntContainLeadingOrTrailingWhitespace()
        {
            var source = "  \t John Doe ";

            var result = source.Trim();

            Assert.AreEqual("John Doe", result);
        }

        [TestMethod]
        public void GivenStringWithWhitespaces_WhenUsingStringBuilder_ThenResultStringDoesntContainWhitespace()
        {
            var source = "  \t John Doe \r\n ";

            static string RemoveWhitespaces(string str)
            {
                var builder = new System.Text.StringBuilder(str.Length);
                for (int i = 0; i < str.Length; i++)
                {
                    char c = str[i];
                    if (!char.IsWhiteSpace(c))
                        builder.Append(c);
                }
                return builder.ToString();
            }

            var result = RemoveWhitespaces(source);

            Assert.AreEqual("JohnDoe", result);
        }

        
    }
}