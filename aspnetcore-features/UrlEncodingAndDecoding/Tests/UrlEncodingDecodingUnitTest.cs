using System.Net;
using System.Web;

namespace Tests
{
    [TestClass]
    public class UrlEncodingDecodingUnitTest
    {
        private const string Url = @"http://example.com/resource?foo=bar with space#fragment";
        private const string EncodedUrlLowerPlus = @"http%3a%2f%2fexample.com%2fresource%3ffoo%3dbar+with+space%23fragment";
        private const string EncodedUrlUpperPercent = @"http%3A%2F%2Fexample.com%2Fresource%3Ffoo%3Dbar%20with%20space%23fragment";
        private const string EncodedUrlUpperPlus = @"http%3A%2F%2Fexample.com%2Fresource%3Ffoo%3Dbar+with+space%23fragment";

        [TestMethod]
        public void GivenAUrl_WhenEncodingWithHttpUtility_ThenCharactersEncoded()
        {
            var encoded = HttpUtility.UrlEncode(Url);

            Assert.AreEqual(EncodedUrlLowerPlus, encoded);
        }

        [DataRow(EncodedUrlLowerPlus)]
        [DataRow(EncodedUrlUpperPercent)]
        [DataRow(EncodedUrlUpperPlus)]
        [DataTestMethod]
        public void GivenAUrl_WhenDecodingWithHttpUtility_ThenCharactersDecoded(string encodedUrl)
        {
            var decoded = HttpUtility.UrlDecode(encodedUrl);

            Assert.AreEqual(Url, decoded);
        }

        [TestMethod]
        public void GivenAUrl_WhenEncodingWithWebUtility_ThenCharactersEncoded()
        {
            var encoded = WebUtility.UrlEncode(Url);

            Assert.AreEqual(EncodedUrlUpperPlus, encoded);
        }

        [DataRow(EncodedUrlLowerPlus)]
        [DataRow(EncodedUrlUpperPercent)]
        [DataRow(EncodedUrlUpperPlus)]
        [DataTestMethod]
        public void GivenAUrl_WhenDecodingWithWebUtility_ThenCharactersDecoded(string encodedUrl)
        {
            var decoded = WebUtility.UrlDecode(encodedUrl);

            Assert.AreEqual(Url, decoded);
        }

        [TestMethod]
        public void GivenAUrl_WhenEncodingWithUri_ThenCharactersEncoded()
        {
            var encoded = Uri.EscapeDataString(Url);

            Assert.AreEqual(EncodedUrlUpperPercent, encoded);
        }

        [DataRow(EncodedUrlUpperPercent)]
        [DataTestMethod]
        public void GivenAUrl_WhenDecodingWithUri_ThenCharactersDecoded(string encodedUrl)
        {
            var decoded = Uri.UnescapeDataString(encodedUrl);

            Assert.AreEqual(Url, decoded);
        }

        [DataRow(EncodedUrlLowerPlus)]
        [DataRow(EncodedUrlUpperPlus)]
        [DataTestMethod]
        public void GivenAUrl_WhenDecodingWithUri_ThenCharactersNotDecoded(string encodedUrl)
        {
            var decoded = Uri.UnescapeDataString(encodedUrl);

            Assert.AreNotEqual(Url, decoded); //Uri.UnescapeDataString does not decode + character to space
        }
    }
}