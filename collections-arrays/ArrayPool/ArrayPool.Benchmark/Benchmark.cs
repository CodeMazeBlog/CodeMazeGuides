using BenchmarkDotNet.Attributes;
using System.Buffers;

namespace ArrayPool.Benchmark;

[InProcess]
[MemoryDiagnoser]
public class Benchmark
{
    private readonly ArrayPool<int> _arrayPool = ArrayPool<int>.Shared;

    [Params(16, 100, 1000, 10000, 100000)]
    public int ArraySize { get; set; }

    [Benchmark]
    public void CreateArrayWithArrayPool()
    {
        var array = _arrayPool.Rent(ArraySize);

        _arrayPool.Return(array);
    }

    [Benchmark]
    public int[] CreateArrayNewArray()
    {
        var array = new int[ArraySize];

        return array;
    }
}
