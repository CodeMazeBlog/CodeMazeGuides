using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using BenchmarkDotNetWithUnitTests;

namespace Tests;

public class BenchmarkFixture
{
    private Summary? _benchmarkSummary;

    public BenchmarkFixture()
    {
        var config = new ManualConfig
        {
            SummaryStyle = SummaryStyle.Default.WithMaxParameterColumnWidth(100),
            Orderer = new DefaultOrderer(SummaryOrderPolicy.FastestToSlowest),
            Options = ConfigOptions.Default
        };

        _benchmarkSummary = BenchmarkRunner.Run<StringConcatBenchmarks>(config);
    }

    public Summary BenchmarkSummary =>
        _benchmarkSummary ?? throw new NullReferenceException("BenchmarkSummary is null");
}