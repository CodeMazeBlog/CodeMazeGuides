namespace Tests
{
    [TestClass]
    public class StringFormattingTests
    {
        [TestMethod]
        public void GivenName_WhenFormatted_ThenHelloWithName()
        {
            var name = "John";

            var formattedString = string.Format("Hello, {0}!", name);

            Assert.AreEqual("Hello, John!", formattedString);
        }

        [TestMethod]
        public void GivenValue_WhenCurlyBracketsEscaped_ThenFormattedStringWithCurlyBrackets()
        {
            var value = "World";

            var formattedString = string.Format("{{Hello, {0}!}}", value);

            Assert.AreEqual("{Hello, World!}", formattedString);
        }

        [TestMethod]
        public void GivenMessage_WhenDoubleQuotesEscaped_ThenFormattedStringWithDoubleQuotes()
        {
            var message = "Important message";

            var formattedString = string.Format("\"{0}\" is the message.", message);

            Assert.AreEqual("\"Important message\" is the message.", formattedString);
        }

        [TestMethod]
        public void GivenPath_WhenBackslashEscaped_ThenFormattedStringWithBackslashes()
        {
            var path = @"C:\Program Files\";

            var formattedString = string.Format("The installation path is: {0}", path);

            Assert.AreEqual("The installation path is: C:\\Program Files\\", formattedString);
        }
    }
}