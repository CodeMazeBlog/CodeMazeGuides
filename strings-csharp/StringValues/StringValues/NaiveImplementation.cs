public class NaiveImplementation
{
    private readonly Dictionary<string, string[]> _headers = [];

    public void AddHeader(string key, string value)
    {
        if (_headers.ContainsKey(key))
        {
            var values = new List<string>(_headers[key]) { value };
            _headers[key] = [.. values];
        }
        else
        {
            _headers[key] = [value];
        }
    }
    public string[] GetHeaderValues(string key)
    {
        return _headers.ContainsKey(key) ? _headers[key] : [];
    }
}