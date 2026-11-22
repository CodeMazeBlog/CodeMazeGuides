using BenchmarkDotNet.Attributes;

namespace BucketSort;

public class BucketSortBenchmarks
{
    private readonly BucketSortMethods _sorter = new();
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
            ? BucketSortMethods.CreateRandomArray(Size)
            : BucketSortMethods.CreateSortedArray(Size);
        _work = new int[Size];
    }

    [Benchmark]
    public int[] SortArray()
    {
        _source.CopyTo(_work, 0);

        return _sorter.SortArray(_work);
    }

    [Benchmark]
    public int[] SortArrayOptimized()
    {
        _source.CopyTo(_work, 0);

        return _sorter.SortArrayOptimized(_work);
    }

    [Benchmark(Baseline = true)]
    public int[] ArraySort()
    {
        _source.CopyTo(_work, 0);
        Array.Sort(_work);

        return _work;
    }
}
