using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using GenerateRandomBooleans.BooleanGenerators;

namespace GenerateRandomBooleans.AlgorithmBenchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
public class BenchmarkGetItemsWithBufferGeneratorVsNextIntegerGenerator : BenchmarkBase
{
    [Params(1_000, 1_000_000)]
    public int NumberOfBooleans { get; set; }

    [Benchmark]
    public long NextIntegerGenerator()
    {
        var generator = new NextIntegerGenerator(RandomGenerator);

        return RoundRobin(generator, NumberOfBooleans);
    }

    [Benchmark]
    public long GetItemsWithBufferGenerator()
    {
        var generator = new GetItemsWithBufferGenerator(RandomGenerator, 128);

        return RoundRobin(generator, NumberOfBooleans);
    }
}
