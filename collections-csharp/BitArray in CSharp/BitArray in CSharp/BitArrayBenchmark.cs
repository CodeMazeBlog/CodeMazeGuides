using BenchmarkDotNet.Attributes;
using System.Collections;

namespace BitArray_in_CSharp;

[MemoryDiagnoser(false)]
public class BitArrayBenchmark
{
    [Params(1000, 1000_000, 100_000_000)]
    public int Size { get; set; }

    [Benchmark]
    public void BitArray()
    {
        BitArray bitArray = new BitArray(Size);
        for (int i = 0; i < bitArray.Length; i++)
        {
            bitArray[i] = true;
        }
    }

    [Benchmark]
    public void BoolArray()
    {
        bool[] boolArray = new bool[Size];
        for (int i = 0; i < boolArray.Length; i++)
        {
            boolArray[i] = true;
        }
    }
}

[MemoryDiagnoser(false)]
public class BitArrayAndBenchmark
{
    private BitArray _bitsLeft = null!;
    private BitArray _bitsRight = null!;
    private bool[] _boolsLeft = null!;
    private bool[] _boolsRight = null!;

    [Params(1000, 1000_000, 100_000_000)]
    public int Size { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _bitsLeft = new BitArray(Size, true);
        _bitsRight = new BitArray(Size, true);
        _boolsLeft = new bool[Size];
        _boolsRight = new bool[Size];
        Array.Fill(_boolsLeft, true);
        Array.Fill(_boolsRight, true);
    }

    [Benchmark]
    public void BitArrayAnd()
    {
        _bitsLeft.And(_bitsRight);
    }

    [Benchmark]
    public void BoolArrayAnd()
    {
        for (int i = 0; i < _boolsLeft.Length; i++)
        {
            _boolsLeft[i] &= _boolsRight[i];
        }
    }
}
