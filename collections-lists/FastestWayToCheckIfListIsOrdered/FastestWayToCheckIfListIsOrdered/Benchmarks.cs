using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Order;

namespace FastestWayToCheckIfListIsOrdered;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[HideColumns(Column.Median, Column.StdDev, Column.Error, Column.Ratio, Column.RatioSD, Column.AllocRatio)]
public class Benchmarks
{
    private List<int> _list = null!;

    [Params(100, 10_000, 1_000_000)]
    public int Length;

    [GlobalSetup]
    public void Setup()
        => _list = Enumerable.Range(0, Length).ToList();

    //[Benchmark(Baseline = true)]
    //public bool IsOrderedUsingForLoop()
    //    => ListOrderValidator.IsOrderedUsingForLoop(_list);

    [Benchmark]
    public bool IsOrderedUsingArraySort()
        => ListOrderValidators.IsOrderedUsingArraySort(_list);

    [Benchmark]
    public bool IsOrderedUsingSpanSort()
        => ListOrderValidators.IsOrderedUsingSpanSort(_list);

    //[Benchmark]
    //public bool IsOrderedUsingSpans()
    //    => ListOrderValidator.IsOrderedUsingSpans(_list);

    //[Benchmark]
    //public bool IsOrderedUsingEnumerator()
    //    => ListOrderValidator.IsOrderedUsingEnumerator(_list);

    //[Benchmark]
    //public bool IsOrderedUsingLinqWithSequenceEqual()
    //    => ListOrderValidator.IsOrderedUsingLinqWithSequenceEqual(_list);

    //[Benchmark]
    //public bool IsOrderedUsingLinqWithOrder()
    //    => ListOrderValidator.IsOrderedUsingLinqWithOrder(_list);

    //[Benchmark]
    //public bool IsOrderedUsingLinqWithZip()
    //    => ListOrderValidator.IsOrderedUsingLinqWithZip(_list);

    //[Benchmark]
    //public bool IsOrderedUsingParallelFor()
    //    => ListOrderValidator.IsOrderedUsingParallelFor(_list);

    //[Benchmark]
    //public bool IsOrderedUsingParallelForWithSpans()
    //    => ListOrderValidator.IsOrderedUsingParallelForWithSpans(_list);

    //[Benchmark]
    //public bool IsOrderedUsingParallelForPartitioned()
    //    => ListOrderValidator.IsOrderedUsingParallelForPartitioned(_list);

    //[Benchmark]
    //public bool IsOrderedUsingParallelForPartitionedWithSpans()
    //    => ListOrderValidator.IsOrderedUsingParallelForPartitionedWithSpans(_list);
}