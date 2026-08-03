using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using BenchmarkDotNetWithUnitTests;
namespace Tests;
public class BenchmarkFixture
{
    public Summary BenchmarkSummary { get; }
    
    public BenchmarkFixture()
    {
        var config = new ManualConfig
        {
            SummaryStyle = SummaryStyle.Default.WithMaxParameterColumnWidth(100),
            Orderer = new DefaultOrderer(SummaryOrderPolicy.FastestToSlowest),
            Options = ConfigOptions.Default
        };
        BenchmarkSummary = BenchmarkRunner.Run<StringConcatBenchmarks>(config);
    }
}