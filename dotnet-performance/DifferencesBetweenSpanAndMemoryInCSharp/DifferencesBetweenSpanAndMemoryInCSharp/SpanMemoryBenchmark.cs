using BenchmarkDotNet.Attributes;

namespace DifferencesBetweenSpanAndMemoryInCSharp;

[MemoryDiagnoser]
public class SpanMemoryBenchmark
{
    private readonly int[] data = [1, 2, 3, 4, 5, 6];

    [Benchmark]
    public Memory<int> SliceAsMemory()
    {
        return data.AsMemory().Slice(2, 1);
    }

    [Benchmark]
    public Span<int> SliceAsSpan()
    {
        return data.AsSpan().Slice(2, 1);
    }
}
