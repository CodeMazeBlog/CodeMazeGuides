using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using RandomAlphaNumericString;

namespace BenchmarkRunner;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class RandomAlphaNumericStringBenchmark
{
    private readonly int length = 16;

    [Benchmark]
    public void UsingRandomNumberGenGetStringMethod()
    {
        Methods.RandomNumberGenGetStringMethod(length);
    }


    [Benchmark]
    public void UsingCryptographicUniqueMethod()
    {
        Methods.CryptographicUniqueMethod(length);
    }

    [Benchmark]
    public void UsingGuidMethod()
    {
        Methods.GuidMethod(length);
    }

    [Benchmark]
    public void UsingLinqMethod()
    {
        Methods.LinqMethod(length);
    }

    [Benchmark]
    public void UsingRandomGetItemsMethod()
    {
        Methods.RandomGetItemsMethod(length);
    }

    [Benchmark]
    public void UsingStringCreateSecureMethod()
    {
        Methods.StringCreateSecureMethod(length);
    }

    [Benchmark]
    public void UsingStringBuilderMethod()
    {
        Methods.StringBuilderMethod(length);
    }

    [Benchmark]
    public void UsingRandomInLoopMethod()
    {
        Methods.RandomInLoopMethod(length);
    }

    [Benchmark]
    public void UsingSpanSecureMethod()
    {
        Methods.SpanSecureMethod(length);
    }

    [Benchmark]
    public void UsingPreSpanSecureMethod()
    {
        Methods.PreSpanSecureMethod(length);
    }

    [Benchmark]
    public void UsingOldSpanSecureMethod()
    {
        Methods.OldSpanSecureMethod(length);
    }
}