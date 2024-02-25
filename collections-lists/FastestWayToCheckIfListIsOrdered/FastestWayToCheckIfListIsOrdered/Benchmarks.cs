using BenchmarkDotNet.Attributes;

namespace FastestWayToCheckIfListIsOrdered;

[MemoryDiagnoser]
[MarkdownExporterAttribute.Default]
public class Benchmarks
{
    [Params(100, 10_000, 1_000_000)] public int Length { get; }

    public List<int> List;

    [GlobalSetup]
    public void Setup()
        => List = Enumerable.Range(0, Length).ToList();


    [Benchmark(Baseline = true)]
    public bool IsOrderedUsingForLoop()
        => ListOrderValidator.IsOrderedUsingForLoop(List);

    [Benchmark]
    public bool IsOrderedUsingArraySort()
        => ListOrderValidator.IsOrderedUsingArraySort(List);

    [Benchmark]
    public bool IsOrderedUsingSpans()
        => ListOrderValidator.IsOrderedUsingSpans(List);

    [Benchmark]
    public bool IsOrderedUsingEnumerator()
        => ListOrderValidator.IsOrderedUsingEnumerator(List);

    [Benchmark]
    public bool IsOrderedUsingLinqWithSequenceEqual()
        => ListOrderValidator.IsOrderedUsingLinqWithSequenceEqual(List);

    [Benchmark]
    public bool IsOrderedUsingLinqWithOrder()
        => ListOrderValidator.IsOrderedUsingLinqWithOrder(List);

    [Benchmark]
    public bool IsOrderedUsingLinqWithZip()
        => ListOrderValidator.IsOrderedUsingLinqWithZip(List);

    [Benchmark]
    public bool IsOrderedUsingParallelFor()
        => ListOrderValidator.IsOrderedUsingParallelFor(List);

    [Benchmark]
    public bool IsOrderedUsingParallelForWithSpans()
        => ListOrderValidator.IsOrderedUsingParallelForWithSpans(List);

    [Benchmark]
    public bool IsOrderedUsingParallelForPartitioned()
        => ListOrderValidator.IsOrderedUsingParallelForPartitioned(List);

    [Benchmark]
    public bool IsOrderedUsingParallelForPartitionedWithSpans()
        => ListOrderValidator.IsOrderedUsingParallelForPartitionedWithSpans(List);
}