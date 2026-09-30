using BenchmarkDotNet.Attributes;

namespace AddValuesToArray.Benchmark;

[MemoryDiagnoser]
[HideColumns("StdDev", "Median", "Gen0", "Gen1", "Gen2")]
public class GrowBenchmark
{
    [Params(1_000, 10_000)]
    public int Count { get; set; }

    [Benchmark]
    public int[] ResizeInALoop() => AddValuesToArrayMethods.GrowWithResize(Count);

    [Benchmark]
    public int[] ListAddThenToArray() => AddValuesToArrayMethods.GrowWithList(Count);
}
