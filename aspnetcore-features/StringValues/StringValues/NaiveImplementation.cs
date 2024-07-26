public class NaiveImplementation
{
    private readonly Dictionary<string, string[]> _headers = [];

    public void AddHeader(string key, params string[] values)
    {
        if (_headers.TryGetValue(key, out var existingValues))
        {
            var newValues = new string[existingValues.Length + values.Length];
            existingValues.CopyTo(newValues, 0);
            values.CopyTo(newValues, existingValues.Length);
            _headers[key] = newValues;
        }
        else
        {
            _headers[key] = values;
        }
    }

    public string[] GetHeaderValues(string key)
    {
        return _headers.TryGetValue(key, out var values) ? values : Array.Empty<string>();
    }
}