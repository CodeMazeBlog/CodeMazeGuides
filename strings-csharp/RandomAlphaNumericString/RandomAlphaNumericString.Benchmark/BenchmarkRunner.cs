using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using RandomAlphaNumericString;

namespace BenchmarkRunner;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class RandomAlphaNumericStringBenchmark
{
    private readonly int length = 10;

    [Benchmark]
    public void UsingAesMethod()
    {
        Methods.AesMethod(length);
    }

    [Benchmark]
    public void UsingPathMethod()
    {
        Methods.PathMethod(length);
    }

    [Benchmark]
    public void UsingRandomNumberGenGetStringMethod()
    {
        Methods.RandomNumberGenGetStringMethod(length);
    }

    [Benchmark]
    public void UsingRandomNumberGenMethod()
    {
        Methods.RandomNumberGenMethod(length);
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
    public void UsingGuidOneLineMethod()
    {
        Methods.GuidOneLineMethod(length);
    }

    [Benchmark]
    public void UsingLinqMethod()
    {
        Methods.LinqMethod(length);
    }

    [Benchmark]
    public void UsingStringCreateMethod()
    {
        Methods.StringCreateMethod(length);
    }

    [Benchmark]
    public void UsingStringCreateSecureMethod()
    {
        Methods.StringCreateSecureMethod(length);
    }

}