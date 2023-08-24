using FirstLetterToUpper;

namespace FirstLetterToUpperTests
{
    [TestClass]
    public class FirstLetterToUpperUnitTests
    {
        FirstLetterToUpperMethods upperCase = new FirstLetterToUpperMethods();

        [TestMethod]
        public void GivenALowerCaseString_WhenUsingSubStringTechnique_VerifyFirstCharIsUpper()
        {
            var testString = "this is a test string";
            var returnedString = upperCase.FirstCharSubstring(testString);

            Assert.IsTrue(char.IsUpper(returnedString[0]));
        }

        [TestMethod]
        public void GivenALowerCaseString_WhenUsingCharToUpperTechnique_VerifyFirstCharIsUpper()
        {
            var testString = "this is a test string";
            var returnedString = upperCase.FirstCharToUpper(testString);

            Assert.IsTrue(char.IsUpper(returnedString[0]));
        }

        [TestMethod]
        public void GivenALowerCaseString_WhenUsingCharArrayTechnique_VerifyFirstCharIsUpper()
        {
            var testString = "this is a test string";
            var returnedString = upperCase.FirstCharToCharArray(testString);

            Assert.IsTrue(char.IsUpper(returnedString[0]));
        }

        [TestMethod]
        public void GivenALowerCaseString_WhenUsingAsSpanTechnique_VerifyFirstCharIsUpper()
        {
            var testString = "this is a test string";
            var returnedString = upperCase.FirstCharToUpperAsSpan(testString);

            Assert.IsTrue(char.IsUpper(returnedString[0]));
        }

        [TestMethod]
        public void GivenALowerCaseString_WhenUsingStringCreateTechnique_VerifyFirstCharIsUpper()
        {
            var testString = "this is a test string";
            var returnedString = upperCase.FirstCharToUpperStringCreate(testString);

            Assert.IsTrue(char.IsUpper(returnedString[0]));
        }

        [TestMethod]
        public void GivenALowerCaseString_WhenUsingRegexTechnique_VerifyFirstCharIsUpper()
        {
            var testString = "this is a test string";
            var returnedString = upperCase.FirstCharToUpperRegex(testString);

            Assert.IsTrue(char.IsUpper(returnedString[0]));
        }

        [TestMethod]
        public void GivenALowerCaseString_WhenUsingLinqTechnique_VerifyFirstCharIsUpper()
        {
            var testString = "this is a test string";
            var returnedString = upperCase.FirstCharToUpperLinq(testString);

            Assert.IsTrue(char.IsUpper(returnedString[0]));
        }

        [TestMethod]
        public void GivenALowerCaseString_WhenUsingUnsafeCodeTechnique_VerifyFirstCharIsUpper()
        {
            var testString = "this is a test string";
            var returnedString = upperCase.FirstCharToUpperUnsafeCode(testString);

            Assert.IsTrue(char.IsUpper(returnedString[0]));
        }
    }
}