using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace BenchmarkDotNetWithUnitTests;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class StringConcatBenchmarks
{
    private const string FirstName = "John";
    private const string LastName = "Doe";

    [Benchmark]
    public string StringConcat()
    {
        return FirstName + " " + LastName;
    }

    [Benchmark]
    public string StringFormat()
    {
        return string.Format("{0} {1}", FirstName, LastName);
    }

    [Benchmark]
    public string StringInterpolation()
    {
        return $"{FirstName} {LastName}";
    }

    [Benchmark]
    public string StringConcatWithJoin()
    {
        return string.Join(" ", FirstName, LastName);
    }
}