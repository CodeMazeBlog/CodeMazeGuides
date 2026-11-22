using BenchmarkDotNet.Attributes;

namespace ShellSort;

public class ShellSortBenchmarks
{
    private readonly ShellSortMethods _sortMethods = new();
    private int[] _source = [];
    private int[] _work = [];

    [Params(4_096, 16_384, 65_536)]
    public int Size { get; set; }

    [Params("Sorted", "Random", "Imbalanced")]
    public string Input { get; set; } = "Random";

    [GlobalSetup]
    public void Setup()
    {
        _source = Input switch
        {
            "Sorted" => ShellSortMethods.CreateSortedArray(Size),
            "Random" => ShellSortMethods.CreateRandomArray(Size, 1, 2_000_000),
            _ => ShellSortMethods.CreateImbalancedArray(Size, 1, 2_000_000)
        };
        _work = new int[Size];
    }

    [Benchmark]
    public int[] ShellSort()
    {
        _source.CopyTo(_work, 0);

        return _sortMethods.ShellSort(_work, Size);
    }
}
