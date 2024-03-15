using AppendValuesToQueryString;
using BenchmarkDotNet.Attributes;

namespace AppendValuesToQueryStringBenchmark
{
    public class ToQueryStringBenchmark
    {
        string url = "https://test.com/Books?author=rowling&language=english#section1";

        Dictionary<string, string> queryParams = new()
        {
            {"genre", "science fiction" },
            {"author", "james martin" }
        };

        [Benchmark]
        public void ModifyQueryStringUsingParseQueryString() =>
        QueryStringHelper.CreateURLUsingParseQueryString(url, queryParams);

        [Benchmark]
        public void ModifyQueryStringUsingParseQuery() =>
            QueryStringHelper.CreateURLUsingParseQuery(url, queryParams);

        [Benchmark]
        public void AppendQueryStringUsingAddQueryString() =>
            QueryStringHelper.CreateURLUsingAddQueryString(url, new Dictionary<string, string?> { { "genre", "science fiction" } });

        [Benchmark]
        public void ModifyQueryStringManually() =>
            QueryStringHelper.CreateURL(url, queryParams);
    }
}
