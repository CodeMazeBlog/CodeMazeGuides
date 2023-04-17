using System.Net;
using System.Web;

namespace Tests
{
    [TestClass]
    public class UrlEncodingDecodingTest
    {
        string url = @"http://example.com/resource?foo=bar#fragment";
        string encodedUrlLower = @"http%3a%2f%2fexample.com%2fresource%3ffoo%3dbar%23fragment";
        string encodedUrlUpper = @"http%3A%2F%2Fexample.com%2Fresource%3Ffoo%3Dbar%23fragment";

        [TestMethod]
        public void GivenAUrl_WhenEncodingWithHttpUtility_ThenCharactersEncoded()
        {
            var encoded = HttpUtility.UrlEncode(url);

            Assert.AreEqual(encodedUrlLower, encoded);
        }

        [TestMethod]
        public void GivenAUrl_WhenDecodingWithHttpUtility_ThenCharactersDecoded()
        {
            var decoded = HttpUtility.UrlDecode(encodedUrlUpper);

            Assert.AreEqual(url, decoded);
        }

        [TestMethod]
        public void GivenAUrl_WhenEncodingWithWebUtility_ThenCharactersEncoded()
        {
            var encoded = WebUtility.UrlEncode(url);

            Assert.AreEqual(encodedUrlUpper, encoded);
        }

        [TestMethod]
        public void GivenAUrl_WhenDecodingWithWebUtility_ThenCharactersDecoded()
        {
            var decoded = WebUtility.UrlDecode(encodedUrlUpper);

            Assert.AreEqual(url, decoded);
        }

        [TestMethod]
        public void GivenAUrl_WhenEncodingWithUri_ThenCharactersEncoded()
        {
            var encoded = Uri.EscapeDataString(url);

            Assert.AreEqual(encodedUrlUpper, encoded);
        }

        [TestMethod]
        public void GivenAUrl_WhenDecodingWithUri_ThenCharactersDecoded()
        {
            var decoded = Uri.UnescapeDataString(encodedUrlUpper);

            Assert.AreEqual(url, decoded);
        }
    }
}