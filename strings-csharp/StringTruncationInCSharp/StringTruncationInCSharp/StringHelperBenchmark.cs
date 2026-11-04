using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;

namespace StringTruncationInCSharp;

[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class StringHelperBenchmark
{
    private readonly string _originalString = new ('a',1_000);

    [Params(10,500,950)] //The test is done for 1%, 50% and 95% of the string length. The string length being 1000.
    public int MaxLength;
        
    [Benchmark]
    public string TruncateWithSubstring()
    {
        return StringHelper.TruncateWithSubstring(_originalString, MaxLength);
    }

    [Benchmark]
    public string TruncateWithForLoopStringBuilder()
    {
        return StringHelper.TruncateWithForLoopStringBuilder(_originalString, MaxLength);
    }

    [Benchmark]
    public string TruncateWithRegularExpressions()
    {
        return StringHelper.TruncateWithRegularExpressions(_originalString, MaxLength);
    }

    [Benchmark]
    public string TruncateWithRemove()
    {
        return StringHelper.TruncateWithRemove(_originalString, MaxLength);
    }

    [Benchmark]
    public string TruncateWithLINQ()
    {
        return StringHelper.TruncateWithLINQ(_originalString, MaxLength);
    }

    [Benchmark]
    public string TruncateWithSpan()
    {
        return StringHelper.TruncateWithSpan(_originalString, MaxLength);
    }

    [Benchmark]
    public string TruncateWithTextElements()
    {
        return StringHelper.TruncateWithTextElements(_originalString, MaxLength);
    }
}