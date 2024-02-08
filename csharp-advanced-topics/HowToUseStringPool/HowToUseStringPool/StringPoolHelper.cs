using CommunityToolkit.HighPerformance;
using CommunityToolkit.HighPerformance.Buffers;
using System.Buffers;
using System.Text.RegularExpressions;

namespace HowtoUseStringPool;

public class StringPoolHelper
{
    private readonly StringPool _myPool;
    private readonly Dictionary<string, string> _cache;
    private readonly List<string> _logger;

    public StringPoolHelper()
    {
        _myPool = new();
        _cache = [];
        _logger = [];
    }

    public bool Init()
    {
        var value1 = _myPool.GetOrAdd("codemaze");
        var value2 = _myPool.GetOrAdd("codemaze");

        return ReferenceEquals(value1, value2);
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
        var cacheKey = BuildCacheKey("USER_", nameSpan);
        var cacheValue = _myPool.GetOrAdd(emailSpan);
        _cache[cacheKey] = cacheValue;

        return true;
    }

    public string GetUser(ReadOnlySpan<char> nameSpan)
    {
        var cacheKey = BuildCacheKey("USER_", nameSpan);
        _cache.TryGetValue(cacheKey, out string value);

        return value;
    }

    private string BuildCacheKey(ReadOnlySpan<char> prefixSpan, ReadOnlySpan<char> keySpan)
    {
        var prefix = _myPool.GetOrAdd(prefixSpan);
        var name = _myPool.GetOrAdd(keySpan);
        var combined = CombineSpan(prefix, name);
        var cacheKey = _myPool.GetOrAdd(combined);

        return cacheKey;
    }

    private static Span<char> CombineSpan(params string[] valueList)
    {
        var size = valueList.Sum(value => value.Length);
        char[] pooledArray = ArrayPool<char>.Shared.Rent(size);
        var combined = new Span<char>(pooledArray, 0, size);
        var position = 0;

        foreach (var value in valueList)
        {
            value.CopyTo(combined[position..]);
            position += value.Length;
        }

        return combined;
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

    public string GetHeaderValue(HttpRequestMessage request, ReadOnlySpan<char> key)
    {
        var keyValue = _myPool.GetOrAdd(key);

        if (request.Headers.Contains(keyValue))
        {
            if (request.Headers.TryGetValues(keyValue, out var headerValues))
            {
                var headerValue = string.Join(",", headerValues);

                return headerValue;
            }
        }

        return string.Empty;
    }

    public bool CheckHeader(HttpRequestMessage request)
    {
        var authorization = GetHeaderValue(request, "Authorization");
        var expectedAgent = _myPool.GetOrAdd("chrome");
        var userAgent = GetHeaderValue(request, "User-Agent");

        if (string.IsNullOrEmpty(authorization))
            return false;

        if (userAgent != expectedAgent)
            return false;

        return true;
    }

    public bool CheckToken(HttpRequestMessage request)
    {
        var token = GetHeaderValue(request, "Authorization");
        var tokenKey = BuildCacheKey("TOKEN_", token);

        if (_cache.ContainsKey(tokenKey))
        {
            var userId = _myPool.GetOrAdd(_cache[tokenKey]);

            return !string.IsNullOrEmpty(userId);
        }

        return false;
    }

    public string Encrypt(string text)
    {
        var passwordKey = _myPool.GetOrAdd("EncryptionPassword");
        var password = _myPool.GetOrAdd(Environment.GetEnvironmentVariable(passwordKey));
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

        return _myPool.GetOrAdd(charArray.AsSpan());
    }

    public string Translate(ReadOnlySpan<char> keySpan, ReadOnlySpan<char> langSpan)
    {
        var prefix = _myPool.GetOrAdd("LOCALIZATION_");
        var lang = _myPool.GetOrAdd(langSpan);
        var key = _myPool.GetOrAdd(keySpan);
        var combined = CombineSpan(prefix, lang, key);

        var calculatedKey = _myPool.GetOrAdd(combined);
        _cache.TryGetValue(calculatedKey, out string? value);

        return value ?? calculatedKey;
    }

    public bool CheckContent(string content)
    {
        var valid = true;
        var blockedWords = new HashSet<string>
        {
            _myPool.GetOrAdd("badword1"),
            _myPool.GetOrAdd("badword2"),
        };

        foreach (var word in content.Split(' '))
        {
            if (blockedWords.Contains(word))
            {
                valid = false;
                break;
            }
        }

        return valid;
    }

    public bool IsValidEmail(string email)
    {
        var pattern = _myPool.GetOrAdd(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

        return Regex.IsMatch(email, pattern);
    }

    public void LogError(ReadOnlySpan<char> detailSpan)
    {
        var prefix = _myPool.GetOrAdd("[ERROR]:");
        var detail = _myPool.GetOrAdd(detailSpan);
        var combined = CombineSpan(prefix, detail);

        var logMessage = _myPool.GetOrAdd(combined);
        _logger.Add(logMessage);
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