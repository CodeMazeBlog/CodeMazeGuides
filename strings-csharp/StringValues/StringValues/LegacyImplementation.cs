using System.Collections.Specialized;

public static class LegacyImplementation
{
    private static readonly NameValueCollection _headers = [];

    public static void AddHeader(string key, string value)
    {
        _headers.Add(key, value);
    }

    public static string[] GetHeaderValues(string key)
    {
        return _headers.GetValues(key) ?? [];
    }
}