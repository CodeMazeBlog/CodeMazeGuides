using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using StringArrayToString;

namespace BenchmarkRunner;

[InProcess]
[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class ArrayConverterBenchmark
{
    private readonly ArrayConverter _arrayConverter = new();
    private string[] _array = [];

    [Params(1_000, 10_000)]
    public int Size { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _array = Enumerable.Repeat("Code-Maze", Size).ToArray();
    }

    [Benchmark]
    public string UsingLoopStringAdditionAssignment() => _arrayConverter.UsingLoopStringAdditionAssignment(_array);

    [Benchmark]
    public string UsingLoopStringBuilder() => _arrayConverter.UsingLoopStringBuilder(_array);

    [Benchmark]
    public string UsingStringJoin() => _arrayConverter.UsingStringJoin(_array);

    [Benchmark]
    public string UsingStringConcat() => _arrayConverter.UsingStringConcat(_array);

    [Benchmark]
    public string UsingAggregation() => _arrayConverter.UsingAggregation(_array);

    [Benchmark]
    public string UsingAggregationWithStringBuilder() => _arrayConverter.UsingAggregationWithStringBuilder(_array);
}
