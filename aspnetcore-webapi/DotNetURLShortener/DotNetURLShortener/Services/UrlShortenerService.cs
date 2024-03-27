using DotNetURLShortener.Contracts;

namespace DotNetURLShortener.Services;

public class UrlShortenerService : IUrlShortenerService
{
    private const string AlphaNumericChars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const int ShortCodeLength = 5;

    public Dictionary<string, string> UrlDict { get; set; } = [];

    public string GetShortCode(string longUrl)
    {
        static string GenerateShortCode()
        {
            var shortCode = new char[ShortCodeLength];
            for (var i = 0; i < ShortCodeLength; i++)
            {
                shortCode[i] = AlphaNumericChars[Random.Shared.Next(AlphaNumericChars.Length)];
            };

            return new string(shortCode);
        }

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