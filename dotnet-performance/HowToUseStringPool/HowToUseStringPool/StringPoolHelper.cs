using CommunityToolkit.HighPerformance.Buffers;
using System.Text;

namespace HowtoUseStringPool;

public class StringPoolHelper
{
    private readonly Dictionary<string, string> _cache = [];

    public static bool Init()
    {
        var myPool = new StringPool();
        var value1 = myPool.GetOrAdd("codemaze");
        var value2 = myPool.GetOrAdd("codemaze"u8, Encoding.UTF8);

        return ReferenceEquals(value1, value2);
    }

    public static bool UseSharedInstance()
    {
        var value1 = StringPool.Shared.GetOrAdd("codemaze");
        var value2 = StringPool.Shared.GetOrAdd("codemaze"u8, Encoding.UTF8);

        return ReferenceEquals(value1, value2);
    }

    public static int GetPoolSize(int minimumSize)
    {
        var myPool = new StringPool(minimumSize);

        return myPool.Size;
    }

    public bool AddUser(ReadOnlySpan<char> nameSpan, ReadOnlySpan<char> emailSpan)
    {
        var cacheKey = BuildCacheKey("USER_", nameSpan);
        var cacheValue = StringPool.Shared.GetOrAdd(emailSpan);
        _cache[cacheKey] = cacheValue;

        return true;
    }

    public string GetUser(ReadOnlySpan<char> nameSpan)
    {
        var cacheKey = BuildCacheKey("USER_", nameSpan);
        _cache.TryGetValue(cacheKey, out var value);

        return value ?? string.Empty;
    }

    private static string BuildCacheKey(ReadOnlySpan<char> prefixSpan, ReadOnlySpan<char> keySpan)
    {
        var prefix = StringPool.Shared.GetOrAdd(prefixSpan);
        var name = StringPool.Shared.GetOrAdd(keySpan);

        using var combined = CombineSpan(prefix, name);
        var cacheKey = StringPool.Shared.GetOrAdd(combined.Span);

        return cacheKey;
    }

    private static SpanOwner<char> CombineSpan(ReadOnlySpan<char> first, ReadOnlySpan<char> second)
    {
        var combinedSpan = SpanOwner<char>.Allocate(first.Length + second.Length);
        var combined = combinedSpan.Span;
        first.CopyTo(combined);
        second.CopyTo(combined[first.Length..]);

        return combinedSpan;
    }

    private static SpanOwner<char> CombineSpan(ReadOnlySpan<char> first, ReadOnlySpan<char> second, ReadOnlySpan<char> third)
    {
        var combinedSpan = SpanOwner<char>.Allocate(first.Length + second.Length + third.Length);
        var combined = combinedSpan.Span;
        first.CopyTo(combined);
        combined = combined[first.Length..];
        second.CopyTo(combined);
        third.CopyTo(combined[second.Length..]);

        return combinedSpan;
    }

    public string GetHostName(string url)
    {
        int offset = url.AsSpan().IndexOf([':', '/', '/']);
        int start = offset == -1 ? 0 : offset + 3;
        int end = url.AsSpan(start).IndexOf('/');

        var hostName = url.AsSpan(start, end);
        var result = StringPool.Shared.GetOrAdd(hostName);

        return result;
    }

    public static string GetHeaderValue(HttpRequestMessage request, ReadOnlySpan<char> key)
    {
        var keyValue = StringPool.Shared.GetOrAdd(key);

        if (request.Headers.TryGetValues(keyValue, out var headerValues))
        {
            var headerValue = string.Join(",", headerValues);

            return headerValue;
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
        var tokenKey = BuildCacheKey("TOKEN_", token);

        if (_cache.TryGetValue(tokenKey, out var value))
        {
            return !string.IsNullOrEmpty(value);
        }

        return false;
    }

    public string Translate(ReadOnlySpan<char> keySpan, ReadOnlySpan<char> langSpan)
    {
        const string prefix = "LOCALIZATION_";

        using var combined = CombineSpan(prefix, langSpan, keySpan);

        var calculatedKey = StringPool.Shared.GetOrAdd(combined.Span);
        _cache.TryGetValue(calculatedKey, out var value);

        return value ?? calculatedKey;
    }

    public bool CacheContains(string key) => _cache.ContainsKey(key);
}