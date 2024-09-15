using BenchmarkDotNet.Attributes;

namespace DifferencesBetweenSpanAndMemoryInCSharp;

[MemoryDiagnoser]
public class SpanMemoryBenchmark
{
    private readonly int[] data = [1, 2, 3, 4, 5, 6];

    [Benchmark]
    public void SliceAsMemory()
    {
       data.AsMemory().Slice(2, 1);
    }

    [Benchmark]
    public void SliceAsSpan()
    {
        data.AsSpan().Slice(2, 1);
    }
}
