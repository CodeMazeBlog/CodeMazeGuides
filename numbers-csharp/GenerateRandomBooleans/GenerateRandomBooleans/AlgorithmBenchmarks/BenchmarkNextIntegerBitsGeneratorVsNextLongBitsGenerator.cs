using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using GenerateRandomBooleans.BooleanGenerators;

namespace GenerateRandomBooleans.AlgorithmBenchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
public class BenchmarkNextIntegerBitsGeneratorVsNextLongBitsGenerator : BenchmarkBase
{
    [Params(1_000, 1_000_000)]
    public int NumberOfBooleans { get; set; }

    [Benchmark(Baseline = true)]
    public long NextIntegerBitsGenerator()
    {
        var generator = new NextIntegerBitsGenerator(RandomGenerator);

        return RoundRobin(generator, NumberOfBooleans);
    }

    [Benchmark]
    public long NextLongBitsGenerator()
    {
        var generator = new NextLongBitsGenerator(RandomGenerator);

        return RoundRobin(generator, NumberOfBooleans);
    }
}
