using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using GenerateRandomBooleans.BooleanGenerators;

namespace GenerateRandomBooleans.AlgorithmBenchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
public class BenchmarkGetItemsWithBufferGenerator : BenchmarkBase
{
    private readonly int NumberOfBooleans = 1_000_000;

    [Params(4, 23, 64, 128, 256, 1024)]
    public int BufferSize { get; set; }

    [Benchmark]
    public long GetItemsWithBufferGenerator()
    {
        var generator = new GetItemsWithBufferGenerator(RandomGenerator, BufferSize);

        return RoundRobin(generator, NumberOfBooleans);
    }
}
