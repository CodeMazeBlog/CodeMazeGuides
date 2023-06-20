using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace BenchmarkDotNetWithUnitTests;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class StringConcatBenchmarks
{
    private string? _firstName;
    private string? _lastName;

    [GlobalSetup]
    public void Setup()
    {
        _firstName = "John";
        _lastName = "Doe";
    }

    [Benchmark]
    public string StringConcat()
    {
        return _firstName + " " + _lastName;
    }

    [Benchmark]
    public string StringFormat()
    {
        return string.Format("{0} {1}", _firstName, _lastName);
    }

    [Benchmark]
    public string StringInterpolation()
    {
        return $"{_firstName} {_lastName}";
    }

    [Benchmark]
    public string StringConcatWithJoin()
    {
        return string.Join(" ", _firstName, _lastName);
    }

    [Benchmark]
    public string StringConcatWithJoinAndArray()
    {
        return string.Join(" ", _firstName, _lastName);
    }

    [Benchmark]
    public string StringConcatWithJoinAndParams()
    {
        return string.Join(" ", _firstName, _lastName);
    }
}