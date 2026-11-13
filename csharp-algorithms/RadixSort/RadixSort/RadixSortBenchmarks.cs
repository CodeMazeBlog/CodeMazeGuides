using BenchmarkDotNet.Attributes;

namespace RadixSort;

public class RadixSortBenchmarks
{
    private readonly RadixSortMethods _radix = new();
    private int[] _source = [];
    private int[] _work = [];

    [Params("Random", "Sorted", "Imbalanced")]
    public string Input { get; set; } = "Random";

    [GlobalSetup]
    public void Setup()
    {
        _source = Input switch
        {
            "Sorted" => RadixSortMethods.CreateSortedArray(20000),
            "Imbalanced" => RadixSortMethods.CreateImbalancedArray(
                RadixSortMethods.CreateRandomArray(19999, 10000, 30000)),
            _ => RadixSortMethods.CreateRandomArray(20000, 10000, 30000)
        };
        _work = new int[_source.Length];
    }

    [Benchmark(Baseline = true)]
    public int[] RadixSort()
    {
        _source.CopyTo(_work, 0);

        return _radix.RadixSort(_work, _work.Length);
    }

    [Benchmark]
    public int[] ArraySort()
    {
        _source.CopyTo(_work, 0);
        Array.Sort(_work);

        return _work;
    }
}
