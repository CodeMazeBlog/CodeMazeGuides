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
        public void GivenValue_WhenCurlyBracketsNotEscaped_ThenThrowsFormatException()
        {
            Assert.ThrowsExactly<FormatException>(() => FormatStringsEscaping.UnescapedCurlyBrackets());
        }

        [TestMethod]
        public void GivenValue_WhenCurlyBracketsEscaped_ThenFormattedStringWithCurlyBrackets()
        {
            var formattedString = FormatStringsEscaping.CurlyBracketsEscaping();

            Assert.AreEqual("{Hello, World!}", formattedString);
        }

        [TestMethod]
        public void GivenValue_WhenCurlyBracketsEscapedInInterpolatedString_ThenStringWithCurlyBrackets()
        {
            var formattedString = FormatStringsEscaping.InterpolatedCurlyBracketsEscaping();

            Assert.AreEqual("{Hello, World!}", formattedString);
        }

        [TestMethod]
        public void GivenNumber_WhenFormatSpecifierInsideEscapedCurlyBrackets_ThenFormattedNumberInCurlyBrackets()
        {
            var formattedString = FormatStringsEscaping.FormatSpecifierInsideCurlyBrackets();

            Assert.AreEqual("Order {00042}", formattedString);
        }

        [TestMethod]
        public void GivenNumber_WhenInterpolatedFormatSpecifierInsideEscapedCurlyBrackets_ThenFormattedNumberInCurlyBrackets()
        {
            var formattedString = FormatStringsEscaping.InterpolatedFormatSpecifierInsideCurlyBrackets();

            Assert.AreEqual("Order {00042}", formattedString);
        }

        [TestMethod]
        public void GivenValues_WhenRawStringLiteralUsed_ThenJsonWithSingleCurlyBrackets()
        {
            var json = FormatStringsEscaping.RawStringLiteralJson();

            var expected = "{" + Environment.NewLine
                + "  \"name\": \"John\"," + Environment.NewLine
                + "  \"age\": 30" + Environment.NewLine
                + "}";
            Assert.AreEqual(expected.ReplaceLineEndings(), json.ReplaceLineEndings());
        }

        [TestMethod]
        public void GivenMessage_WhenDoubleQuotesEscaped_ThenFormattedStringWithDoubleQuotes()
        {
            var formattedString = FormatStringsEscaping.DoubleQuotesEscaping();

            Assert.AreEqual("\"Important message\" is the message.", formattedString);
        }

        [TestMethod]
        public void GivenMessage_WhenDoubleQuotesInVerbatimString_ThenSameResult()
        {
            var formattedString = FormatStringsEscaping.DoubleQuotesInVerbatimString();

            Assert.AreEqual("\"Important message\" is the message.", formattedString);
        }

        [TestMethod]
        public void GivenMessage_WhenDoubleQuotesInRawStringLiteral_ThenSameResult()
        {
            var formattedString = FormatStringsEscaping.DoubleQuotesInRawStringLiteral();

            Assert.AreEqual("\"Important message\" is the message.", formattedString);
        }

        [TestMethod]
        public void GivenPath_WhenBackslashEscaped_ThenFormattedStringWithBackslashes()
        {
            var formattedString = FormatStringsEscaping.BackslashEscaping();

            Assert.AreEqual("The installation path is: C:\\Program Files\\", formattedString);
        }

        [TestMethod]
        public void GivenPath_WhenBackslashInVerbatimString_ThenSameResult()
        {
            var formattedString = FormatStringsEscaping.BackslashInVerbatimString();

            Assert.AreEqual("The installation path is: C:\\Program Files\\", formattedString);
        }
    }
}
