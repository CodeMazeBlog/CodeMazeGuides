using System.Collections.Specialized;

public class LegacyImplementation
{
    private readonly NameValueCollection _headers = [];

    public void AddHeader(string key, string value)
    {
        _headers.Add(key, value);
    }

    public string[] GetHeaderValues(string key)
    {
        return _headers.GetValues(key) ?? [];
    }
}