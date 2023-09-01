using BenchmarkDotNet.Attributes;
using System.Buffers;

namespace ArrayPool.Benchmark;

[MemoryDiagnoser]
public class Benchmark
{
    [Params(100, 1000, 10000, 100000)]
    private int ArraySize { get; set; }

    private ArrayPool<int>? arrayPool;

    [GlobalSetup]
    public void GlobalSetup()
    {
        arrayPool = ArrayPool<int>.Shared;
    }

    [Benchmark]
    public void CreateArrayWithArrayPool()
    {
        var array = arrayPool.Rent(ArraySize);

        arrayPool.Return(array);
    }

    [Benchmark]
    public void CreateArrayNewArray()
    {
        var array = new int[ArraySize];
    }
}
