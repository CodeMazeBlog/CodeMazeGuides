using CommunityToolkit.HighPerformance.Buffers;
using System.Text;

namespace HowtoUseStringPool;

public class StringPoolHelper
{
    private readonly Dictionary<string, string> _cache = [];
    private StringPool _myPool;

    public bool Init(int poolSize)
    {
        _myPool = new StringPool(poolSize);
        var value1 = _myPool.GetOrAdd("codemaze");
        var value2 = _myPool.GetOrAdd("codemaze"u8, Encoding.UTF8);

        return ReferenceEquals(value1, value2);
    }

    public int GetPoolSize()
    {
        return _myPool.Size;
    }

    public static bool UseSharedInstance()
    {
        var value1 = StringPool.Shared.GetOrAdd("codemaze");
        var value2 = StringPool.Shared.GetOrAdd("codemaze"u8, Encoding.UTF8);

        return ReferenceEquals(value1, value2);
    }

    public bool AddUser(ReadOnlySpan<char> nameSpan, ReadOnlySpan<char> emailSpan)
    {
        var cacheKey = CombineSpan("USER_", nameSpan);
        var cacheValue = StringPool.Shared.GetOrAdd(emailSpan);
        _cache[cacheKey] = cacheValue;

        return true;
    }

    public string GetUser(ReadOnlySpan<char> nameSpan)
    {
        var cacheKey = CombineSpan("USER_", nameSpan);
        _cache.TryGetValue(cacheKey, out var value);

        return value ?? string.Empty;
    }

    private static string CombineSpan(ReadOnlySpan<char> first, ReadOnlySpan<char> second)
    {
        var combinedSpan = SpanOwner<char>.Allocate(first.Length + second.Length);
        var combined = combinedSpan.Span;
        first.CopyTo(combined);
        second.CopyTo(combined[first.Length..]);

        return StringPool.Shared.GetOrAdd(combinedSpan.Span);
    }

    private static string CombineSpan(ReadOnlySpan<char> first, ReadOnlySpan<char> second, ReadOnlySpan<char> third)
    {
        var combinedSpan = SpanOwner<char>.Allocate(first.Length + second.Length + third.Length);
        var combined = combinedSpan.Span;
        first.CopyTo(combined);
        combined = combined[first.Length..];
        second.CopyTo(combined);
        third.CopyTo(combined[second.Length..]);

        return StringPool.Shared.GetOrAdd(combinedSpan.Span);
    }

    public string GetHostName(ReadOnlySpan<char> urlSpan)
    {
        int offset = urlSpan.IndexOf([':', '/', '/']);
        int start = offset == -1 ? 0 : offset + 3;
        int end = start + urlSpan[start..].IndexOf('/');
        var hostName = urlSpan[start..end];

        return StringPool.Shared.GetOrAdd(hostName);
    }

    public static string GetHeaderValue(HttpRequestMessage request, ReadOnlySpan<char> key)
    {
        var keyValue = StringPool.Shared.GetOrAdd(key);

        if (request.Headers.TryGetValues(keyValue, out var headerValues))
        {
            if (headerValues.Count() > 1)
                return string.Join(",", headerValues);

            return headerValues.FirstOrDefault();
        }

        return string.Empty;
    }

    public static bool CheckHeader(HttpRequestMessage request)
    {
        const string expectedAgent = "chrome";
        var authorization = GetHeaderValue(request, "Authorization");
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
        var tokenKey = CombineSpan("TOKEN_", token);

        if (_cache.TryGetValue(tokenKey, out var value))
        {
            return !string.IsNullOrEmpty(value);
        }

        return false;
    }

    public string Translate(ReadOnlySpan<char> keySpan, ReadOnlySpan<char> langSpan)
    {
        const string prefix = "LOCALIZATION_";

        var calculatedKey = CombineSpan(prefix, langSpan, keySpan);
        _cache.TryGetValue(calculatedKey, out var value);

        return value ?? calculatedKey;
    }

    public bool CacheContains(string key) => _cache.ContainsKey(key);
}