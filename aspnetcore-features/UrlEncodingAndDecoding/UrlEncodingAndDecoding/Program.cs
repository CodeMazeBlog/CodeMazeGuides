using System.Net;
using System.Web;

var value = "bar with space&more";

var httpUtilityEncoded = HttpUtility.UrlEncode(value);
var webUtilityEncoded = WebUtility.UrlEncode(value);
var uriEncoded = Uri.EscapeDataString(value);

Console.WriteLine($"http://example.com/resource?foo={httpUtilityEncoded}");
Console.WriteLine($"http://example.com/resource?foo={webUtilityEncoded}");
Console.WriteLine($"http://example.com/resource?foo={uriEncoded}");

Console.WriteLine(HttpUtility.UrlDecode(httpUtilityEncoded));
Console.WriteLine(WebUtility.UrlDecode(webUtilityEncoded));
Console.WriteLine(Uri.UnescapeDataString(uriEncoded));
