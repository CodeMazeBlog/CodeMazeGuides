using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;

namespace ImprovePerformanceWithSourceGeneratedRegEx;

[MemoryDiagnoser(true)]
[Config(typeof(StyleConfig))]
public class RegexBenchmarks
{
    private const string Password = "c0d3-MaZ3-Pa55w0rd";

    [Benchmark(Baseline = true)]
    public void RegularRegex()
        => PasswordValidator.ValidatePasswordWithRegularRegEx(Password);

    [Benchmark]
    public void CompiledRegex()
        => PasswordValidator.ValidatePasswordWithCompiledRegEx(Password);

    [Benchmark]
    public void SourceGeneratedRegex()
        => PasswordValidator.ValidatePasswordWithSourceGeneratedRegEx(Password);

    private class StyleConfig : ManualConfig
    {
        public StyleConfig()
            => SummaryStyle = SummaryStyle.Default.WithRatioStyle(RatioStyle.Trend);
    }
}
