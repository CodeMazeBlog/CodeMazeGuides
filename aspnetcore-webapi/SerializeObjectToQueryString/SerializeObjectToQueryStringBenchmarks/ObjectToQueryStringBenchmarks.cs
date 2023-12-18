using BenchmarkDotNet.Attributes;
using SerializeObjectToQueryString;

namespace SerializeObjectToQueryStringBenchmarks;

public class ObjectToQueryStringBenchmarks
{
    private static readonly Book _book = new();

    [Benchmark]
    public void SerializeObjectToQueryStringUsingReflection() =>
        QueryStringSerializer.CreateURLWithBookAsQueryParamsUsingReflection("https://test.com", _book);

    [Benchmark]
    public void SerializeObjectToQueryStringUsingNewtonsoftJson() =>
        QueryStringSerializer.CreateURLWithBookAsQueryParamsUsingNewtonsoftJson("https://test.com", _book);
}