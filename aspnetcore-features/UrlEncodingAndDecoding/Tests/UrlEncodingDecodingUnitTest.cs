using System.Net;
using System.Web;

namespace Tests
{
    [TestClass]
    public class UrlEncodingDecodingUnitTest
    {
        private const string Value = "bar with space&more";
        private const string EncodedWithPlus = "bar+with+space%26more";
        private const string EncodedWithPercent = "bar%20with%20space%26more";

        [TestMethod]
        public void GivenAValue_WhenEncodingWithHttpUtility_ThenSpaceBecomesPlus()
        {
            var encoded = HttpUtility.UrlEncode(Value);

            Assert.AreEqual(EncodedWithPlus, encoded);
        }

        [TestMethod]
        public void GivenAValue_WhenEncodingWithWebUtility_ThenSpaceBecomesPlus()
        {
            var encoded = WebUtility.UrlEncode(Value);

            Assert.AreEqual(EncodedWithPlus, encoded);
        }

        [TestMethod]
        public void GivenAValue_WhenEncodingWithUri_ThenSpaceBecomesPercent20()
        {
            var encoded = Uri.EscapeDataString(Value);

            Assert.AreEqual(EncodedWithPercent, encoded);
        }

        [TestMethod]
        public void GivenAnEncodedValue_WhenDecodingWithHttpUtility_ThenValueRestored()
        {
            var decoded = HttpUtility.UrlDecode(EncodedWithPlus);

            Assert.AreEqual(Value, decoded);
        }

        [TestMethod]
        public void GivenAnEncodedValue_WhenDecodingWithWebUtility_ThenValueRestored()
        {
            var decoded = WebUtility.UrlDecode(EncodedWithPlus);

            Assert.AreEqual(Value, decoded);
        }

        [TestMethod]
        public void GivenAnEncodedValue_WhenDecodingWithUri_ThenValueRestored()
        {
            var decoded = Uri.UnescapeDataString(EncodedWithPercent);

            Assert.AreEqual(Value, decoded);
        }

        [TestMethod]
        public void GivenAPlusEncodedValue_WhenDecodingWithUri_ThenPlusIsNotConvertedToSpace()
        {
            var decoded = Uri.UnescapeDataString(EncodedWithPlus);

            Assert.AreNotEqual(Value, decoded); // Uri.UnescapeDataString leaves '+' as a literal plus
        }
    }
}
