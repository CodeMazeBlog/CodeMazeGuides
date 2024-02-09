using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace HowToCheckIfURLIsValid;

public static class UrlValidator
{
    public static bool ValidateUrlWithRegex(string url)
    {
        var urlRegex = new Regex(
                 @"^(https?|ftps?):\/\/(?:[a-zA-Z0-9]" +
                   @"(?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?\.)+[a-zA-Z]{2,}" +
                   @"(?::(?:0|[1-9]\d{0,3}|[1-5]\d{4}|6[0-4]\d{3}" +
                   @"|65[0-4]\d{2}|655[0-2]\d|6553[0-5]))?" +
                   @"(?:\/(?:[-a-zA-Z0-9@%_\+.~#?&=]+\/?)*)?$",
            RegexOptions.IgnoreCase);
        
        return urlRegex.IsMatch(url);
    }

    public static bool ValidateUrlWithUriCreate(string url, out Uri? uri)
    {
        var success = Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out uri);
        
        return success;
    }

    public static bool ValidateUrlWithUriWellFormedString(string url)
    {
        var success = Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute);
        
        return success;
    }

    public static async Task<bool> ValidateUrlWithHttpClient(string url)
    {
        using var client = new HttpClient();
        try
        {
            var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));
            
            return response.IsSuccessStatusCode;
        }
        catch (HttpRequestException e)
            when (e.InnerException is SocketException
                  { SocketErrorCode: SocketError.HostNotFound })
        {
            return false;
        }
        catch (HttpRequestException e)
            when (e.StatusCode.HasValue && (int)e.StatusCode.Value > 500)
        {
            return true;
        }
    }
}
