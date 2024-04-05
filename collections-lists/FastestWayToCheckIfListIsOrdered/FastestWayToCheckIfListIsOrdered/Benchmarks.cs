using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;

namespace FastestWayToCheckIfListIsOrdered;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
[HideColumns(Column.Median, Column.StdDev, Column.Error, Column.Ratio, Column.RatioSD,
    Column.AllocRatio, Column.Gen0, Column.Gen1, Column.Gen2)]
public class Benchmarks
{
    private List<int> _list = null!;

    [Params( 10_000, 25_000, 1_000_000)]
    public int Length;

    [GlobalSetup]
    public void Setup()
        => _list = Enumerable.Range(0, Length).ToList();

    [Benchmark(Baseline = true)]
    public bool IsOrderedUsingForLoop()
        => ListOrderValidators.IsOrderedUsingForLoop(_list);

    [Benchmark]
    public bool IsOrderedUsingSpanSort()
        => ListOrderValidators.IsOrderedUsingSpanSort(_list);

    [Benchmark]
    public bool IsOrderedUsingSpans()
        => ListOrderValidators.IsOrderedUsingForLoopWithSpan(_list);

    [Benchmark]
    public bool IsOrderedUsingEnumerator()
        => ListOrderValidators.IsOrderedUsingEnumerator(_list);

    [Benchmark]
    public bool IsOrderedUsingLinqWithSequenceEqual()
        => ListOrderValidators.IsOrderedUsingLinqWithSequenceEqual(_list);

    [Benchmark]
    public bool IsOrderedUsingLinqWithOrder()
        => ListOrderValidators.IsOrderedUsingLinqWithOrder(_list);

    [Benchmark]
    public bool IsOrderedUsingLinqWithZip()
        => ListOrderValidators.IsOrderedUsingLinqWithZip(_list);

    [Benchmark]
    public bool IsOrderedUsingParallelFor()
        => ListOrderValidators.IsOrderedUsingParallelFor(_list);

    [Benchmark]
    public bool IsOrderedUsingParallelForPartitioned()
        => ListOrderValidators.IsOrderedUsingParallelForPartitioned(_list);

    [Benchmark]
    public bool IsOrderedUsingParallelForPartitionedWithSpans()
        => ListOrderValidators.IsOrderedUsingParallelForPartitionedWithSpans(_list);
}