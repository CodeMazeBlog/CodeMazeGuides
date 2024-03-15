using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using IdentifyIfAStringIsANumber;

namespace BenchmarkRunner;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser]
public class StringIsANumberBenchmark
{
    private string value = "123456789";

    [Benchmark]
    public void IntTryParse()
    {
        StringIsANumberChecker.IntTryParse(value);
    }

    [Benchmark]
    public void DoubleTryParse()
    {
        StringIsANumberChecker.DoubleTryParse(value);
    }

    [Benchmark]
    public void UsingRegex()
    {
        StringIsANumberChecker.UsingRegex(value);
    }

    [Benchmark]
    public void UsingCompiledRegex()
    {
        StringIsANumberChecker.UsingCompiledRegex(value);
    }

    [Benchmark]
    public void UsingCharIsDigit()
    {
        StringIsANumberChecker.UsingCharIsDigit(value);
    }

    [Benchmark]
    public void UsingCharIsDigitWithForeach()
    {
        StringIsANumberChecker.UsingCharIsDigitWithForeach(value);
    }

    [Benchmark]
    public void UsingCharIsBetween09()
    {
        StringIsANumberChecker.UsingCharIsBetween09(value);
    }
}
