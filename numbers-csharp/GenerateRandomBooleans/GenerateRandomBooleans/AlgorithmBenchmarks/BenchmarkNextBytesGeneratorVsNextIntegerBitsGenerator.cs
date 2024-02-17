using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using GenerateRandomBooleans.BooleanGenerators;

namespace GenerateRandomBooleans.AlgorithmBenchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
public class BenchmarkNextBytesGeneratorVsNextIntegerBitsGenerator : BenchmarkBase
{
    [Params(1_000, 1_000_000)]
    public int NumberOfBooleans { get; set; }

    [Benchmark]
    public long NextBytesGenerator()
    {
        var generator = new NextBytesGenerator(RandomGenerator, 128);

        return RoundRobin(generator, NumberOfBooleans);
    }

    [Benchmark]
    public long NextIntegerBitsGenerator()
    {
        var generator = new NextIntegerBitsGenerator(RandomGenerator);

        return RoundRobin(generator, NumberOfBooleans);
    }
}
