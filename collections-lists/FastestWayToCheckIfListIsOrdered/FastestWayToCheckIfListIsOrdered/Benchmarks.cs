using System.Buffers;
using BenchmarkDotNet.Attributes;

namespace FastestWayToCheckIfListIsOrdered;

[MemoryDiagnoser]
[MarkdownExporterAttribute.Default]
public class Benchmarks
{
    
    [Params(100, 10_000, 1_000_000)]
    public int Length { get; set; }

    private ArrayPool<int> _pool;

    public int[] Array;

    public List<int> List;

    [GlobalSetup]
    public void Setup()
    {
        Array = Enumerable.Range(0, Length).ToArray();
        _pool = ArrayPool<int>.Shared;
        
        List = Array.ToList();
    }

    [Benchmark(Baseline = true)]
    public void IsOrderedUsingForLoop()
    {
        var isOrdered = ListOrderValidator.IsOrderedUsingForLoop(List);
    }
    
    [Benchmark]
    public void IsOrderedUsingArraySort()
    {
        var isOrdered = ListOrderValidator.IsOrderedUsingArraySort(List, _pool);
    }

    [Benchmark]
    public void IsOrderedUsingSpans()
    {
        var isOrdered = ListOrderValidator.IsOrderedUsingSpans(List);
    }
    
    // [Benchmark]
    // public void IsOrderedUsingEnumerator()
    // {
    //     var isOrdered = ListOrderValidator.IsOrderedUsingEnumerator(List);
    // }
    //
    // [Benchmark]
    // public void IsOrderedUsingLinqWithSequenceEqual()
    // {
    //     var isOrdered = ListOrderValidator.IsOrderedUsingLinqWithSequenceEqual(List);
    // }
    //
    // [Benchmark]
    // public void IsOrderedUsingLinqWithOrder()
    // {
    //     var isOrdered = ListOrderValidator.IsOrderedUsingLinqWithOrder(List);
    // }
    //
    // [Benchmark]
    // public void IsOrderedUsingLinqWithZip()
    // {
    //     var isOrdered = ListOrderValidator.IsOrderedUsingLinqWithZip(List);
    // }
    //
    // [Benchmark]
    // public void IsOrderedUsingParallelFor()
    // {
    //     var isOrdered = ListOrderValidator.IsOrderedUsingParallelFor(List);
    // }
    //
    // [Benchmark]
    // public void IsOrderedUsingParallelForWithSpans()
    // {
    //     var isOrdered = ListOrderValidator.IsOrderedUsingParallelForWithSpans(List);
    // }
    //
    // [Benchmark]
    // public void IsOrderedUsingParallelForPartitioned()
    // {
    //     var isOrdered = ListOrderValidator.IsOrderedUsingParallelForPartitioned(List);
    // }
    //
    // [Benchmark]
    // public void IsOrderedUsingParallelForPartitionedWithSpans()
    // {
    //     var isOrdered = ListOrderValidator.IsOrderedUsingParallelForPartitionedWithSpans(List);
    // }
}