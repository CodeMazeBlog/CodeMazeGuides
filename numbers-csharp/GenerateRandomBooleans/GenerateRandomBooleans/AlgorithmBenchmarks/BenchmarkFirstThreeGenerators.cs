using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using GenerateRandomBooleans.BooleanGenerators;

namespace GenerateRandomBooleans.AlgorithmBenchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
public class BenchmarkFirstThreeGenerators : BenchmarkBase
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
    public long NextDoubleGenerator()
    {
        var generator = new NextDoubleGenerator(RandomGenerator);

        return RoundRobin(generator, NumberOfBooleans);
    }

    [Benchmark]
    public long GetItemsGenerator()
    {
        var generator = new GetItemsGenerator(RandomGenerator);

        return RoundRobin(generator, NumberOfBooleans);
    }
}
