using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;

namespace BaselineStylingInBenchmarkDotNet;

public class StyleConfig : ManualConfig
{
    public StyleConfig()
    {
        SummaryStyle = SummaryStyle.Default.WithRatioStyle(RatioStyle.Trend);
    }
}