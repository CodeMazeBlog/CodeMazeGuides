using BenchmarkDotNet.Attributes;
using System.Buffers;

namespace ArrayPool.Benchmark;

[MemoryDiagnoser]
public class Benchmark
{
    private ArrayPool<int>? _arrayPool;

    [Params(100, 1000, 10000, 100000)]
    public int ArraySize { get; set; }    

    [GlobalSetup]
    public void GlobalSetup()
    {
        _arrayPool = ArrayPool<int>.Shared;
    }

    [Benchmark]
    public void CreateArrayWithArrayPool()
    {
        var array = _arrayPool.Rent(ArraySize);

        _arrayPool.Return(array);
    }

    [Benchmark]
    public void CreateArrayNewArray()
    {
        var array = new int[ArraySize];
    }
}