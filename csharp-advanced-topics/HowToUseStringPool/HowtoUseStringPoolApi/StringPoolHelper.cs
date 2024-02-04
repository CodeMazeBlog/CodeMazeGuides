using CommunityToolkit.HighPerformance;
using CommunityToolkit.HighPerformance.Buffers;
using System;
using System.Text.RegularExpressions;

namespace HowtoUseStringPoolApi;

public class StringPoolHelper(IConfiguration configuration)
{
    private readonly StringPool _myPool = new();
    private readonly Dictionary<string, string> _cache = [];
    private readonly List<string> _logger = [];
    private readonly IConfiguration _configuration = configuration;

    public string Init()
    {
        var value1 = _myPool.GetOrAdd("codemaze".AsSpan());
        var value2 = _myPool.GetOrAdd("codemaze".AsSpan());

        return string.Format("Hash of value1: {0}, value2: {1}",
             value1.GetHashCode(), value2.GetHashCode());
    }

    public string SharedInstance(ReadOnlySpan<char> message)
    {
        string result;
        if (_myPool.Size <= 10)
            result = _myPool.GetOrAdd(message);
        else
            result = StringPool.Shared.GetOrAdd(message);

        return result;
    }

    public bool AddUser(ReadOnlySpan<char> nameSpan, ReadOnlySpan<char> emailSpan)
    {
        var prefixSpan = "USER_".AsSpan();
        var prefix = _myPool.GetOrAdd(prefixSpan);
        var name = _myPool.GetOrAdd(nameSpan);

        Span<char> combined = stackalloc char[prefixSpan.Length + nameSpan.Length];
        prefix.CopyTo(combined);
        name.CopyTo(combined[prefix.Length..]);

        var cacheKey = _myPool.GetOrAdd(combined);
        var cacheValue = _myPool.GetOrAdd(emailSpan);
        _cache[cacheKey] = cacheValue;

        return true;
    }

    public string GetUser(ReadOnlySpan<char> nameSpan)
    {
        var prefixSpan = "USER_".AsSpan();
        var prefix = _myPool.GetOrAdd(prefixSpan);
        var name = _myPool.GetOrAdd(nameSpan);

        Span<char> combined = stackalloc char[prefixSpan.Length + nameSpan.Length];
        prefix.CopyTo(combined);
        name.CopyTo(combined[prefix.Length..]);

        var cacheKey = _myPool.GetOrAdd(combined);
        _cache.TryGetValue(cacheKey, out string value);

        return value;
    }

    public void LogError(ReadOnlySpan<char> detailSpan)
    {
        var prefixSpan = "[ERROR]:".AsSpan();
        var prefix = _myPool.GetOrAdd(prefixSpan);
        var detail = _myPool.GetOrAdd(detailSpan);

        Span<char> combined = stackalloc char[prefixSpan.Length + detailSpan.Length];
        prefix.CopyTo(combined);
        detail.CopyTo(combined[prefix.Length..]);

        var logMessage = _myPool.GetOrAdd(combined);
        _logger.Add(logMessage);
    }

    public string GetHostName(string url)
    {
        int offset = url.AsSpan().IndexOf([':', '/', '/']);
        int start = offset == -1 ? 0 : offset + 3;
        int end = url.AsSpan(start).IndexOf('/');

        ReadOnlySpan<char> hostName = url.AsSpan(start, end);
        var result = _myPool.GetOrAdd(hostName);

        return result;
    }

    public string GetHeaderValue(HttpRequest request, ReadOnlySpan<char> key)
    {
        string keyValue = _myPool.GetOrAdd(key);

        if (request.Headers.ContainsKey(keyValue))
            return _myPool.GetOrAdd(request.Headers[keyValue]);

        return string.Empty;
    }

    public bool CheckHeader(HttpRequest request)
    {
        string authorization = GetHeaderValue(request, "Authorization".AsSpan());
        if (string.IsNullOrEmpty(authorization))
            return false;

        var expectedContentType = _myPool.GetOrAdd("application/json".AsSpan());
        string contentType = GetHeaderValue(request, "Content-Type".AsSpan());

        if (contentType != expectedContentType)
            return false;

        return true;
    }

    public bool CheckToken(HttpRequest request)
    {
        var tokenPrefix = "TOKEN_".AsSpan();
        var prefix = _myPool.GetOrAdd(tokenPrefix);
        var token = GetHeaderValue(request, "AuthorizationToken".AsSpan());

        Span<char> combined = stackalloc char[tokenPrefix.Length + token.Length];
        prefix.CopyTo(combined);
        token.CopyTo(combined[prefix.Length..]);

        var tokenKey = _myPool.GetOrAdd(combined);
        if (_cache.ContainsKey(tokenKey))
        {
            var userId = _myPool.GetOrAdd(_cache[tokenKey]);

            return !string.IsNullOrEmpty(userId);
        }

        return false;
    }

    public string Encrypt(string text)
    {
        var passwordKey = _myPool.GetOrAdd("EncryptionPassword".AsSpan());
        var password = _myPool.GetOrAdd(_configuration.GetValue<string>(passwordKey));

        var charArray = new char[text.Length * 2];
        var ind = 0;

        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                char shiftedChar = (char)(((c - 'A' + 3) % 26) + 'A');
                charArray[2 * ind] = char.IsLower(c) ? char.ToLower(shiftedChar) : shiftedChar;
            }
            else
            {
                charArray[2 * ind] = c;
            }
            charArray[2 * ind + 1] = password.Length > ind ? password[ind++] : '$';
        }

        var encryptedText = charArray.ToString();

        return encryptedText;
    }

    public string Translate(ReadOnlySpan<char> keySpan, ReadOnlySpan<char> langSpan)
    {
        var prefixSpan = "LOCALIZATION_".AsSpan();
        var prefix = _myPool.GetOrAdd(prefixSpan);
        var lang = _myPool.GetOrAdd(langSpan);
        var key = _myPool.GetOrAdd(keySpan);

        Span<char> combined = stackalloc char[prefixSpan.Length + langSpan.Length+ keySpan.Length];
        prefix.CopyTo(combined);
        lang.CopyTo(combined[prefix.Length..]);
        key.CopyTo(combined[(prefix.Length+lang.Length)..]);

        var calculatedKey = _myPool.GetOrAdd(combined);
        _cache.TryGetValue(calculatedKey, out string? value);

        return value ?? calculatedKey;
    }

    public bool IsValidEmail(string email)
    {
        var patternSpan = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$".AsSpan();
        string pattern = _myPool.GetOrAdd(patternSpan);

        return Regex.IsMatch(email, pattern);
    }

    public bool CheckContent(string content)
    {
        var blockedWords = new HashSet<string>
        {
            _myPool.GetOrAdd("badword1"),
            _myPool.GetOrAdd("badword2"),
        };

        var valid = true;
        foreach (string word in content.Split(' '))
        {
            if (blockedWords.Contains(word))
            {
                valid = false;
                break;
            }
        }

        return valid;
    }

    public bool CacheContains(string key)
    {
        return _cache.ContainsKey(key);
    }

    public int GetLogCount()
    {
        return _logger.Count;
    }
}