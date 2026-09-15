using System.Net;
using System.Text.Encodings.Web;
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
        [TestMethod]
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
        [TestMethod]
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
        [TestMethod]
        public void GivenAUrl_WhenDecodingWithUri_ThenCharactersDecoded(string encodedUrl)
        {
            var decoded = Uri.UnescapeDataString(encodedUrl);

            Assert.AreEqual(Url, decoded);
        }

        [DataRow(EncodedUrlLowerPlus)]
        [DataRow(EncodedUrlUpperPlus)]
        [TestMethod]
        public void GivenAUrl_WhenDecodingWithUri_ThenCharactersNotDecoded(string encodedUrl)
        {
            var decoded = Uri.UnescapeDataString(encodedUrl);

            Assert.AreNotEqual(Url, decoded); //Uri.UnescapeDataString does not decode + character to space
        }

        [TestMethod]
        public void GivenAUrl_WhenEncodingWithUrlEncoder_ThenCharactersEncoded()
        {
            var encoded = UrlEncoder.Default.Encode(Url);

            Assert.AreEqual(EncodedUrlUpperPercent, encoded);
        }

        [TestMethod]
        public void GivenAVeryLongString_WhenEscapingWithUri_ThenNoLengthLimitApplies()
        {
            var longValue = new string('a', 100_000) + " ";

            var encoded = Uri.EscapeDataString(longValue);

            Assert.AreEqual(100_003, encoded.Length);
        }

        [TestMethod]
        public void GivenTheEncodeUriComponentSafeCharacters_WhenEscapingWithUri_ThenTheyAreEscaped()
        {
            var encoded = Uri.EscapeDataString("!'()*~");

            Assert.AreEqual("%21%27%28%29%2A~", encoded);
        }

        [TestMethod]
        public void GivenABarePath_WhenConstructingAUri_ThenTheOutcomeIsPlatformDependent()
        {
            if (OperatingSystem.IsWindows())
            {
                //A bare path is not an absolute URI on Windows and not a rooted local path either.
                Assert.ThrowsExactly<UriFormatException>(() => new Uri("/foo"));
                Assert.IsFalse(Uri.TryCreate("/foo", UriKind.Absolute, out _));
            }
            else
            {
                //On Unix a bare path IS a rooted local path, so it parses as an absolute file URI.
                var uri = new Uri("/foo");

                Assert.AreEqual("file", uri.Scheme);
                Assert.AreEqual("file:///foo", uri.AbsoluteUri);
                Assert.IsTrue(Uri.TryCreate("/foo", UriKind.Absolute, out _));
            }

            //The relative remedy works the same way on every platform.
            Assert.IsTrue(Uri.TryCreate("/foo", UriKind.Relative, out _));
            Assert.IsFalse(new Uri("/foo", UriKind.Relative).IsAbsoluteUri);
        }

        [TestMethod]
        public void GivenAProtocolRelativeUrl_WhenConstructingAUri_ThenItParsesAsAFileUri()
        {
            //Same on Windows and on Unix: this does not throw, it becomes a file URI.
            var uri = new Uri("//example.com");

            Assert.AreEqual("file", uri.Scheme);
            Assert.AreEqual("file://example.com/", uri.AbsoluteUri);
            Assert.IsTrue(Uri.TryCreate("//example.com", UriKind.Absolute, out _));
        }
    }
}