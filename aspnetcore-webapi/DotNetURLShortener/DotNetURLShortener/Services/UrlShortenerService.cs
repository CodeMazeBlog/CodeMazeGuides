using DotNetURLShortener.Contracts;

namespace DotNetURLShortener.Services;

public class UrlShortenerService : IUrlShortenerService
{
    private static readonly char[] _chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    private Dictionary<string, string> UrlDict { get; set; } = [];

    private static string GenerateShortCode()
    {
        return string.Create(5, _chars, (shortCode, charsState)
            => Random.Shared.GetItems(charsState, shortCode));
    }

    public string GetShortCode(string longUrl)
    {
        foreach (var pair in UrlDict)
        {
            if (pair.Value == longUrl)
            {
                return pair.Key;
            }
        }

        string shortCode;
        while (true)
        {
            shortCode = GenerateShortCode();
            if (UrlDict.TryAdd(shortCode, longUrl))
            {
                break;
            }
        }

        return shortCode;
    }

    public string? GetLongUrl(string shortCode)
    {
        if (UrlDict.TryGetValue(shortCode, out string? longUrl))
        {
            return longUrl;
        }

        return default;
    }
}