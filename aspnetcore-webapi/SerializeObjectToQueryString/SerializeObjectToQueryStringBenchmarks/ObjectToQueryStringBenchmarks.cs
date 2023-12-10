using BenchmarkDotNet.Attributes;
using SerializeObjectToQueryString;

namespace SerializeObjectToQueryStringBenchmarks
{
    public class ObjectToQueryStringBenchmarks
    {
        [Benchmark]
        public void SerializeObjectToQueryStringUsingReflection() =>
            QueryStringSerializer.CreateURLWithBookAsQueryParamsUsingReflection("https://test.com", new Book());

        [Benchmark]
        public void SerializeObjectToQueryStringUsingNewtonsoftJson() =>
            QueryStringSerializer.CreateURLWithBookAsQueryParamsUsingNewtonsoftJson("https://test.com", new Book());

    }
}
