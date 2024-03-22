using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;

namespace BenchmarkAcrossDifferentDotNETVersions;

[SimpleJob(RuntimeMoniker.Net60, baseline: true)]
[SimpleJob(RuntimeMoniker.Net70)]
[SimpleJob(RuntimeMoniker.Net80)]
[Config(typeof(StyleConfig))]
public class GetBooksBenchmark
{
    private class StyleConfig : ManualConfig
    {
        public StyleConfig()
            => SummaryStyle = SummaryStyle.Default.WithRatioStyle(RatioStyle.Trend);
    }

    [Benchmark]
    public List<Book> GetBooks() => BookService.GetBooks();
}