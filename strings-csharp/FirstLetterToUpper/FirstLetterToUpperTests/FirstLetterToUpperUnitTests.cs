using FirstLetterToUpper;

namespace FirstLetterToUpperTests
{
    [TestClass]
    public class FirstLetterToUpperUnitTests
    {
        [TestMethod]
        public void GivenALowerCaseString_WhenUsingSubStringTechnique_VerifyFirstCharIsUpper()
        {
            var upperCase = new FirstLetterToUpperMethods();

            var testString = "this is a test string";
            var returnedString = upperCase.FirstCharSubstring(testString);

            Assert.IsTrue(char.IsUpper(returnedString[0]));
        }

        [TestMethod]
        public void GivenALowerCaseString_WhenUsingCharToUpperTechnique_VerifyFirstCharIsUpper()
        {
            var upperCase = new FirstLetterToUpperMethods();

            var testString = "this is a test string";
            var returnedString = upperCase.FirstCharToUpper(testString);

            Assert.IsTrue(char.IsUpper(returnedString[0]));
        }

        [TestMethod]
        public void GivenALowerCaseString_WhenUsingCharArrayTechnique_VerifyFirstCharIsUpper()
        {
            var upperCase = new FirstLetterToUpperMethods();

            var testString = "this is a test string";
            var returnedString = upperCase.FirstCharToCharArray(testString);

            Assert.IsTrue(char.IsUpper(returnedString[0]));
        }

        [TestMethod]
        public void GivenALowerCaseString_WhenUsingAsSpanTechnique_VerifyFirstCharIsUpper()
        {
            var upperCase = new FirstLetterToUpperMethods();

            var testString = "this is a test string";
            var returnedString = upperCase.FirstCharToUpperAsSpan(testString);

            Assert.IsTrue(char.IsUpper(returnedString[0]));
        }

        [TestMethod]
        public void GivenALowerCaseString_WhenUsingRegexTechnique_VerifyFirstCharIsUpper()
        {
            var upperCase = new FirstLetterToUpperMethods();

            var testString = "this is a test string";
            var returnedString = upperCase.FirstCharToUpperRegex(testString);

            Assert.IsTrue(char.IsUpper(returnedString[0]));
        }

        [TestMethod]
        public void GivenALowerCaseString_WhenUsingLinqTechnique_VerifyFirstCharIsUpper()
        {
            var upperCase = new FirstLetterToUpperMethods();

            var testString = "this is a test string";
            var returnedString = upperCase.FirstCharToUpperLinq(testString);

            Assert.IsTrue(char.IsUpper(returnedString[0]));
        }

        [TestMethod]
        public void GivenALowerCaseString_WhenUsingUnsafeCodeTechnique_VerifyFirstCharIsUpper()
        {
            var upperCase = new FirstLetterToUpperMethods();

            var testString = "this is a test string";
            var returnedString = upperCase.FirstCharToUpperUnsafeCode(testString);

            Assert.IsTrue(char.IsUpper(returnedString[0]));
        }
    }
}