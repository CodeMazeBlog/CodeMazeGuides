using BenchmarkDotNet.Attributes;

namespace HeapSort;

public class HeapSortBenchmarks
{
    private const int Size = 2_000_000;

    private readonly HeapSortMethods _heapSort = new();
    private int[] _source = [];
    private int[] _work = [];

    [Params("Random", "Sorted", "Identical")]
    public string Input { get; set; } = "Random";

    [GlobalSetup]
    public void Setup()
    {
        _source = Input switch
        {
            "Sorted" => HeapSortMethods.CreateSortedArray(Size),
            "Identical" => HeapSortMethods.CreateIdenticalArray(Size, 1, Size),
            _ => HeapSortMethods.CreateRandomArray(Size, 1, Size)
        };
        _work = new int[Size];
    }

    [Benchmark]
    public int[] SortArray()
    {
        _source.CopyTo(_work, 0);

        return _heapSort.SortArray(_work, Size);
    }
}
