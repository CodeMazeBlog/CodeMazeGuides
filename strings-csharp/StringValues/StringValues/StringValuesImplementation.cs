using Microsoft.Extensions.Primitives;

public static class StringValuesImplementation
{
    private static readonly Dictionary<string, StringValues> _headers = [];

    public static Dictionary<string, StringValues> AddHeader(string key, string value)
    {
        if (_headers.ContainsKey(key))
        {
            _headers[key] = StringValues.Concat(_headers[key], value);
        }
        else
        {
            _headers[key] = new StringValues(value);
        }
        return _headers;
    }

    public static void DisplayHeaders()
    {
        foreach (var header in _headers)
        {
            StringValues value = header.Value;
            Console.WriteLine($"{header.Key}:");

            if (value.Count == 1)
            {
                string? single = value;
                Console.WriteLine(single);
            }
            else
            {
                foreach (var val in value)
                {
                    Console.WriteLine(val);
                }
            }
        }
    }

    public static StringValues GetHeaderValues(string key)
    {
        return _headers.ContainsKey(key) ? _headers[key] : StringValues.Empty;
    }
}
