using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ReplaceSpecialCharactersInString
{
    [TestClass]
    public class ReplaceSpecialCharactersInStringTests
    {
        [TestMethod]
        public void WhenUsingStringReplace_ThenReplaceSpecialCharacters()
        {
            string expected = "String.Replace Method: Hello! This is a sample string.";
            string result = RunExampleMethodAndCaptureConsoleOutput(ReplaceSpecialCharactersInString.StringReplaceExample, expected);
            
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenDemonstratingLossOfOriginalStructureInStringReplace_ThenReplaceSpecialCharacters()
        {
            string expected = "Loss of Original Structure using String.Replace: apple banana cherry";
            string result = RunExampleMethodAndCaptureConsoleOutput(ReplaceSpecialCharactersInString.LossOfOriginalStructureStringReplaceExample, expected);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenDemonstratingInefficientMultipleReplacementsInStringReplace_ThenReplaceSpecialCharacters()
        {
            string expected = "Inefficient for Multiple Replacements using String.Replace Method: abdef";
            string result = RunExampleMethodAndCaptureConsoleOutput(ReplaceSpecialCharactersInString.InefficientMultipleReplacementsStringReplaceExample, expected);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenDemonstratingMemoryImpactInStringReplace_ThenReplaceSpecialCharacters()
        {
            string expected = "Memory Impact using String.Replace Method: ab";
            string result = RunExampleMethodAndCaptureConsoleOutput(ReplaceSpecialCharactersInString.MemoryImpactStringReplaceExample, expected);

            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void WhenUsingStringBuilder_ThenReplaceMultipleSpecialCharacters()
        {
            string expected = "StringBuilder for Multiple Replacements: abdef";
            string result = RunExampleMethodAndCaptureConsoleOutput(ReplaceSpecialCharactersInString.StringBuilderExample, expected);
            
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenUsingRegex_ThenReplaceSpecialCharacters()
        {
            string expected = "Regular Expressions (Regex): Hello! This is a sample string.";
            string result = RunExampleMethodAndCaptureConsoleOutput(ReplaceSpecialCharactersInString.RegexExample, expected);
            
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenUsingSpanT_ThenReplaceSpecialCharactersWithMemoryEfficient()
        {
            string expected = "Memory-Efficient Replacements with Span<T>: Hello! This is a  string.";
            string result = RunExampleMethodAndCaptureConsoleOutput(ReplaceSpecialCharactersInString.SpanTExample, expected);
           
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenUsingCompiledRegex_ThenReplaceSpecialCharacters()
        {
            string expected = "Compiled Regex for Repeated Operations: Hello! This is a sample string.";
            string result = RunExampleMethodAndCaptureConsoleOutput(ReplaceSpecialCharactersInString.CompiledRegexExample, expected);
            
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenUsingDotNet8Features_ThenSpecialCharacterRemoved()
        {
            string expected = ".NET 8 Features: Hello! This is a sample string.";
            string result = RunExampleMethodAndCaptureConsoleOutput(ReplaceSpecialCharactersInString.DotNet8FeaturesExample, expected);
            
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void WhenUsingUnsafeCode_ThenReplaceSpecialCharacters()
        {
            string expected = "Unsafe Code for Direct Memory Access: Hello! This is a *sample* string.";
            string result = RunExampleMethodAndCaptureConsoleOutput(ReplaceSpecialCharactersInString.UnsafeCodeExample, expected);
            
            Assert.AreEqual(expected, result);
        }

        private string RunExampleMethodAndCaptureConsoleOutput(Action method, string expectedOutput)
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                method.Invoke();

                Console.SetOut(Console.Out);

                string result = Regex.Replace(sw.ToString(), @"[^\u0020-\u007E]", "");

                return result;
            }
        }

    }
}