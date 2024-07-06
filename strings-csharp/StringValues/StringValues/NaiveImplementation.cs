public class NaiveImplementation
{
    private readonly Dictionary<string, string[]> _headers = [];

    public void AddHeader(string key, string value)
    {
        if (_headers.ContainsKey(key))
        {
            var existingValues = _headers[key];
            Array.Resize(ref existingValues, existingValues.Length + 1);
            existingValues[existingValues.Length - 1] = value;
            _headers[key] = existingValues;
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