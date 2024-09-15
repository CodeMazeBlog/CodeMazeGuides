using Microsoft.Extensions.Primitives;

public class StringValuesImplementation
{
    private readonly Dictionary<string, StringValues> _headers = new();

    public void DemonstrateStringValues()
    {
        StringValues singleValue = new StringValues("value1");
        Console.WriteLine(singleValue);

        StringValues multipleValues = new StringValues(new[] { "value1", "value2" });
        Console.WriteLine(multipleValues);

        StringValues implicitSingle = "value1";
        Console.WriteLine($"Implicit Single Value: {implicitSingle}");

        StringValues implicitMultiple = new[] { "value1", "value2" };
        Console.WriteLine($"Implicit Multiple Values: {implicitMultiple}");

        StringValues values = new StringValues(new[] { "value1", "value2" });
        Console.WriteLine($"Comma-Separated Values: {values}");

        StringValues emptyValue = new StringValues();
        Console.WriteLine(emptyValue.Count);

        StringValues nullValue = new StringValues((string)null);
        Console.WriteLine(nullValue.Count);
    }

    public void AddHeader(string key, params string[] values)
    {
        if (_headers.TryGetValue(key, out var existingValues))
        {
            _headers[key] = StringValues.Concat(existingValues, new StringValues(values));
        }
        else
        {
            _headers[key] = new StringValues(values);
        }
    }

    public StringValues GetHeaderValues(string key)
    {
        return _headers.TryGetValue(key, out var values) ? values : StringValues.Empty;
    }

    public void DisplayHeaders()
    {
        foreach (var (key, value) in _headers)
        {
            Console.WriteLine($"{key}: {value}");
        }
    }
}
