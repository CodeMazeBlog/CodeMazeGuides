using BenchmarkDotNet.Attributes;

namespace MergeSort;

[MemoryDiagnoser]
public class MergeBenchmarks
{
    private readonly Merge _merge = new();
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
            ? Merge.GenerateRandomNumber(Size)
            : Merge.GenerateSortedNumber(Size);
        _work = new int[Size];
    }

    [Benchmark]
    public int[] SortArray()
    {
        _source.CopyTo(_work, 0);

        return _merge.SortArray(_work, 0, _work.Length - 1);
    }
}
