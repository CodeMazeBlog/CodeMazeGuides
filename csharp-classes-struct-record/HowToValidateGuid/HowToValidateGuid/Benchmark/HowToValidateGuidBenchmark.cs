using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using HowToValidateGuid;

namespace HowToUseStringPool.Benchmark;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
[HideColumns(Column.StdDev, Column.Error)]
[MemoryDiagnoser]
public class HowToValidateGuidBenchmark
{
    private readonly string _guidString = Guid.NewGuid().ToString();
    private readonly string _nonGuidString = "loremipsum-sid-dolar-amet-34648208e86d";
    private readonly string _format = "D";

    [Params(1000, 10000, 100000)] public int Iterations;

    [Benchmark]
    public void UseValidateWithRegex()
    {
        for (var i = 0; i < Iterations; i++)
        {
            var input = i % 2 == 0 ? _guidString : _nonGuidString;
            GuidHelper.ValidateWithRegex(input);
        }
    }

    [Benchmark]
    public void UseValidateWithGuidParse()
    {
        for (var i = 0; i < Iterations; i++)
        {
            var input = i % 2 == 0 ? _guidString : _nonGuidString;
            GuidHelper.ValidateWithGuidParse(input);
        }
    }

    [Benchmark]
    public void UseValidateWithGuidParseExact()
    {
        for (var i = 0; i < Iterations; i++)
        {
            var input = i % 2 == 0 ? _guidString : _nonGuidString;
            GuidHelper.ValidateWithGuidParseExact(input, _format);
        }
    }

    [Benchmark]
    public void UseValidateWithGuidTryParse()
    {
        for (var i = 0; i < Iterations; i++)
        {
            var input = i % 2 == 0 ? _guidString : _nonGuidString;
            GuidHelper.ValidateWithGuidTryParse(input);
        }
    }

    [Benchmark]
    public void UseValidateWithGuidTryParseExact()
    {
        for (var i = 0; i < Iterations; i++)
        {
            var input = i % 2 == 0 ? _guidString : _nonGuidString;
            GuidHelper.ValidateWithGuidTryParseExact(input, _format);
        }
    }

    [Benchmark]
    public void UseValidateWithNewGuid()
    {
        for (var i = 0; i < Iterations; i++)
        {
            var input = i % 2 == 0 ? _guidString : _nonGuidString;
            GuidHelper.ValidateWithNewGuid(input);
        }
    }
}