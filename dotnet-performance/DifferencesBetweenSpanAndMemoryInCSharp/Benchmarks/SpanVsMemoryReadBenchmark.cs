using BenchmarkDotNet.Attributes;

namespace SpanMemoryBench;

// The published benchmark slices a six element array once per operation, which lands under a
// nanosecond and is swamped by timer noise. This one reads a whole buffer, which is the work a
// caller actually does, and it separates the two ways of reading through Memory: asking for the
// Span on every element, and taking the Span once and looping over that.
[MemoryDiagnoser]
public class SpanVsMemoryReadBenchmark
{
    private readonly int[] _data = CreateData();

    private static int[] CreateData()
    {
        var data = new int[4096];
        for (var i = 0; i < data.Length; i++)
        {
            data[i] = i;
        }

        return data;
    }

    [Benchmark(Description = "Sum through Span")]
    public int SumThroughSpan()
    {
        var span = _data.AsSpan();
        var sum = 0;
        for (var i = 0; i < span.Length; i++)
        {
            sum += span[i];
        }

        return sum;
    }

    [Benchmark(Description = "Sum through Memory.Span per element")]
    public int SumThroughMemory()
    {
        var memory = _data.AsMemory();
        var sum = 0;
        for (var i = 0; i < memory.Length; i++)
        {
            sum += memory.Span[i];
        }

        return sum;
    }

    [Benchmark(Description = "Sum through Memory, Span taken once")]
    public int SumThroughMemorySpanTakenOnce()
    {
        var memory = _data.AsMemory();
        var span = memory.Span;
        var sum = 0;
        for (var i = 0; i < span.Length; i++)
        {
            sum += span[i];
        }

        return sum;
    }
}
