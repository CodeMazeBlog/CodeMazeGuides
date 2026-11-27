using BenchmarkDotNet.Attributes;

namespace QuickSort;

public class QuickSortBenchmarks
{
    private readonly QuickSortMethods _sorter = new();
    private int[] _source = [];
    private int[] _work = [];

    [Params(200, 1000, 2000)]
    public int Size { get; set; }

    [Params("Unsorted", "Sorted")]
    public string Input { get; set; } = "Unsorted";

    [GlobalSetup]
    public void Setup()
    {
        _source = Input == "Sorted"
            ? QuickSortMethods.CreateSortedArray(Size)
            : QuickSortMethods.CreateRandomArray(Size);
        _work = new int[Size];
    }

    [Benchmark(Baseline = true)]
    public int[] FirstElementPivot()
    {
        _source.CopyTo(_work, 0);
        return _sorter.SortArray(_work, 0, _work.Length - 1);
    }

    [Benchmark]
    public int[] MiddleElementPivot()
    {
        _source.CopyTo(_work, 0);
        return _sorter.SortArrayWithMiddlePivot(_work, 0, _work.Length - 1);
    }

    [Benchmark]
    public int[] ArraySort()
    {
        _source.CopyTo(_work, 0);
        Array.Sort(_work);
        return _work;
    }
}
