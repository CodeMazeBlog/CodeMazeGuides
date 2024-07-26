using System.Collections.Specialized;

public class LegacyImplementation
{
    private readonly NameValueCollection _headers = [];

    public void AddHeader(string key, params string[] values)
    {
        foreach (var value in values)
        {
            _headers.Add(key, value);
        }
    }

    public string[] GetHeaderValues(string key)
    {
        return _headers.GetValues(key) ?? [];
    }
}