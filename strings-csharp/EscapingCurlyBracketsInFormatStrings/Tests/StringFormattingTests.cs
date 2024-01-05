using EscapingCurlyBracketsInFormatStrings;

namespace Tests
{
    [TestClass]
    public class StringFormattingTests
    {
        [TestMethod]
        public void GivenName_WhenFormatted_ThenHelloWithName()
        {
            var formattedString = FormatStringsEscaping.FormatStringExample();
            Assert.AreEqual("Hello, John!", formattedString);
        }

        [TestMethod]
        public void GivenValue_WhenCurlyBracketsEscaped_ThenFormattedStringWithCurlyBrackets()
        {
            var formattedString = FormatStringsEscaping.CurlyBracketsEscaping();
            Assert.AreEqual("{Hello, World!}", formattedString);
        }

        [TestMethod]
        public void GivenMessage_WhenDoubleQuotesEscaped_ThenFormattedStringWithDoubleQuotes()
        {
            var formattedString = FormatStringsEscaping.DoubleQuotesEscaping();
            Assert.AreEqual("\"Important message\" is the message.", formattedString);
        }

        [TestMethod]
        public void GivenPath_WhenBackslashEscaped_ThenFormattedStringWithBackslashes()
        {
            var formattedString = FormatStringsEscaping.BackslashEscaping();
            Assert.AreEqual("The installation path is: C:\\Program Files\\", formattedString);
        }
    }
}