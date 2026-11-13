using BenchmarkDotNet.Attributes;

namespace CountingSort;

public class CountingSortBenchmarks
{
    private readonly CountingSortMethods _sorter = new();
    private int[] _source = [];
    private int[] _work = [];

    [Params("Best Case", "Average Case", "Worst Case")]
    public string Input { get; set; } = "Average Case";

    [GlobalSetup]
    public void Setup()
    {
        _source = Input switch
        {
            "Best Case" => CountingSortMethods.CreateRandomArray(20_000, 1, 2),
            "Average Case" => CountingSortMethods.CreateRandomArray(20_000, 10_000, 30_000),
            _ => CountingSortMethods.CreateImbalancedArray(
                CountingSortMethods.CreateRandomArray(19_999, 10_000, 30_000))
        };
        _work = new int[_source.Length];
    }

    [Benchmark]
    public int[] CountingSort()
    {
        _source.CopyTo(_work, 0);

        return _sorter.CountingSort(_work);
    }

    [Benchmark(Baseline = true)]
    public int[] ArraySort()
    {
        _source.CopyTo(_work, 0);
        Array.Sort(_work);

        return _work;
    }
}
