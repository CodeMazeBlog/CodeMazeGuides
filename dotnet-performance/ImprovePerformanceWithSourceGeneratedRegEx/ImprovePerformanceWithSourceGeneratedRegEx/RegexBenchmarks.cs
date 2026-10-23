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
    public bool RegularRegex()
        => PasswordValidator.ValidatePasswordWithRegularRegEx(Password);

    [Benchmark]
    public bool StaticRegex()
        => PasswordValidator.ValidatePasswordWithStaticRegEx(Password);

    [Benchmark]
    public bool CompiledRegex()
        => PasswordValidator.ValidatePasswordWithCompiledRegEx(Password);

    [Benchmark]
    public bool NewCompiledRegex()
        => PasswordValidator.ValidatePasswordWithNewCompiledRegEx(Password);

    [Benchmark]
    public bool SourceGeneratedRegex()
        => PasswordValidator.ValidatePasswordWithSourceGeneratedRegEx(Password);

    private class StyleConfig : ManualConfig
    {
        public StyleConfig()
            => SummaryStyle = SummaryStyle.Default.WithRatioStyle(RatioStyle.Trend);
    }
}
