using BenchmarkDotNet.Attributes;

namespace SelectionSort;

public class SelectionBenchmarks
{
    private readonly Selection _selection = new();
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
            ? Selection.AddRandomElements(Size)
            : Selection.AddSortedElements(Size);
        _work = new int[Size];
    }

    [Benchmark]
    public int[] SortArray()
    {
        _source.CopyTo(_work, 0);
        _selection.NumArray = _work;

        return _selection.SortArray();
    }
}
