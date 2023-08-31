using System.Net;
using System.Web;

var url = @"http://example.com/resource?foo=bar with space#fragment";

var httpUtilityEncoded = HttpUtility.UrlEncode(url);
var httpUtilityDecoded = HttpUtility.UrlDecode(httpUtilityEncoded);

var webUtilityEncoded = WebUtility.UrlEncode(url);
var webUtilityDecoded = WebUtility.UrlDecode(webUtilityEncoded);

var uriEncoded = Uri.EscapeDataString(url);
var uriDecoded = Uri.UnescapeDataString(uriEncoded);

Console.WriteLine(httpUtilityEncoded);
Console.WriteLine(webUtilityEncoded);
Console.WriteLine(uriEncoded);

Console.WriteLine(httpUtilityDecoded);
Console.WriteLine(webUtilityDecoded);
Console.WriteLine(uriDecoded);