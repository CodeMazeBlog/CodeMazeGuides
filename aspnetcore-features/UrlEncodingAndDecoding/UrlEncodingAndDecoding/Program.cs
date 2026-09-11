using System.Net;
using System.Text.Encodings.Web;
using System.Web;

var url = @"http://example.com/resource?foo=bar with space#fragment";

var httpUtilityEncoded = HttpUtility.UrlEncode(url);
var httpUtilityDecoded = HttpUtility.UrlDecode(httpUtilityEncoded);

var webUtilityEncoded = WebUtility.UrlEncode(url);
var webUtilityDecoded = WebUtility.UrlDecode(webUtilityEncoded);

var uriEncoded = Uri.EscapeDataString(url);
var uriDecoded = Uri.UnescapeDataString(uriEncoded);

var urlEncoderEncoded = UrlEncoder.Default.Encode(url);

Console.WriteLine(httpUtilityEncoded);
Console.WriteLine(webUtilityEncoded);
Console.WriteLine(uriEncoded);
Console.WriteLine(urlEncoderEncoded);

Console.WriteLine(httpUtilityDecoded);
Console.WriteLine(webUtilityDecoded);
Console.WriteLine(uriDecoded);

// In real code we encode a single value, not the address it goes into:
var searchUrl = $"https://example.com/search?q={Uri.EscapeDataString("bar with space")}";

Console.WriteLine(searchUrl);