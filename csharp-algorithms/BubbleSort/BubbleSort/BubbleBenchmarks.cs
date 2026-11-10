using BenchmarkDotNet.Attributes;

namespace BubbleSort;

public class BubbleBenchmarks
{
    private readonly Bubble _bubble = new();
    private int[] _source = [];
    private int[] _work = [];

    [Params(200, 2_000, 20_000)]
    public int Size { get; set; }

    [Params("Random", "Sorted")]
    public string Input { get; set; } = "Random";

    [GlobalSetup]
    public void Setup()
    {
        _source = Input == "Random"
            ? Bubble.GenerateRandomNumber(Size)
            : Bubble.GenerateSortedNumber(Size);
        _work = new int[Size];
    }

    [Benchmark]
    public int[] SortArray()
    {
        _source.CopyTo(_work, 0);
        _bubble.NumArray = _work;

        return _bubble.SortArray();
    }

    [Benchmark]
    public int[] SortOptimizedArray()
    {
        _source.CopyTo(_work, 0);
        _bubble.NumArray = _work;

        return _bubble.SortOptimizedArray();
    }
}
