using BenchmarkDotNet.Attributes;

namespace InsertionSort;

public class InsertionSortBenchmarks
{
    private readonly InsertionSortMethods _sortFunction = new();
    private int[] _source = [];
    private int[] _work = [];

    [Params(100, 1_000, 10_000)]
    public int Size { get; set; }

    [Params("Random", "Sorted", "Reversed")]
    public string Input { get; set; } = "Random";

    [GlobalSetup]
    public void Setup()
    {
        _source = Input switch
        {
            "Sorted" => InsertionSortMethods.CreateSortedArray(Size),
            "Reversed" => InsertionSortMethods.CreateReversedArray(
                InsertionSortMethods.CreateSortedArray(Size)),
            _ => InsertionSortMethods.CreateRandomArray(Size)
        };
        _work = new int[Size];
    }

    [Benchmark]
    public int[] SortArray()
    {
        _source.CopyTo(_work, 0);

        return _sortFunction.SortArray(_work, _work.Length);
    }

    [Benchmark]
    public int[] SortArrayRecursive()
    {
        _source.CopyTo(_work, 0);

        return _sortFunction.SortArrayRecursive(_work, _work.Length);
    }
}
