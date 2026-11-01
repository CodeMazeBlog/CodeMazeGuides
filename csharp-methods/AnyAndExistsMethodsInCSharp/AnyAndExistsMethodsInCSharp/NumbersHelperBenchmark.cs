using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace AnyAndExistsMethodsInCSharp;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class NumbersHelperBenchmark
{
    [Params(10_000, 100_000, 1_000_000)]
    public int ListSize { get; set; }

    private List<int> _list = [];

    [GlobalSetup]
    public void GlobalSetup()
    {
        _list = Enumerable.Range(-ListSize, ListSize).ToList();
    }

    [Benchmark(Baseline = true)]
    public bool ComparePositiveNumbersMethodsExists()
        => NumbersHelper.CheckIfListContainsPositiveNumbersExists(_list);

    [Benchmark]
    public bool ComparePositiveNumbersMethodsAny()
        => NumbersHelper.CheckIfListContainsPositiveNumbersAny(_list);
}
