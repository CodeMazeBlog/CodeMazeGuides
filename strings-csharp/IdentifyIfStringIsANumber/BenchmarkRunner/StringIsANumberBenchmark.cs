using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using IdentifyIfAStringIsANumber;

namespace BenchmarkRunner;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser]
public class StringIsANumberBenchmark
{
    [Params("123456789", "a12345678")]
    public string Value { get; set; } = string.Empty;

    [Benchmark]
    public void IntTryParse()
    {
        StringIsANumberChecker.IntTryParse(Value);
    }

    [Benchmark]
    public void DoubleTryParse()
    {
        StringIsANumberChecker.DoubleTryParse(Value);
    }

    [Benchmark]
    public void UsingRegex()
    {
        StringIsANumberChecker.UsingRegex(Value);
    }

    [Benchmark]
    public void UsingCompiledRegex()
    {
        StringIsANumberChecker.UsingCompiledRegex(Value);
    }

    [Benchmark]
    public void UsingCharIsDigit()
    {
        StringIsANumberChecker.UsingCharIsDigit(Value);
    }

    [Benchmark]
    public void UsingCharIsDigitWithForeach()
    {
        StringIsANumberChecker.UsingCharIsDigitWithForeach(Value);
    }

    [Benchmark]
    public void UsingCharIsBetween09()
    {
        StringIsANumberChecker.UsingCharIsBetween09(Value);
    }
}
