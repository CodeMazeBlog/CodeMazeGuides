using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using GenerateRandomBooleans.BooleanGenerators;
using GenerateRandomBooleans.RandomGenerators;

namespace GenerateRandomBooleans.AlgorithmBenchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
public class BenchmarkFirstThreePlusDirectGetItems : BenchmarkBase
{
    [Params(1_000, 1_000_000)]
    public int NumberOfBooleans { get; set; }

    public bool[] Buffer { get; set; } = null!;

    [GlobalSetup]
    public void Setup()
    {
        Buffer = new bool[NumberOfBooleans];
    }

    [Benchmark]
    public void NextIntegerGenerator()
    {
        var generator = new NextIntegerGenerator(RandomGenerator);
        StoreEverything(generator, Buffer);
    }

    [Benchmark]
    public void NextDoubleGenerator()
    {
        var generator = new NextDoubleGenerator(RandomGenerator);
        StoreEverything(generator, Buffer);
    }

    [Benchmark]
    public void GetItemsGenerator()
    {
        var generator = new GetItemsGenerator(RandomGenerator);
        StoreEverything(generator, Buffer);
    }

    [Benchmark]
    public void GetItemsDirectGenerator()
    {
        var r = new SystemRandomGenerator();
        var _ = r.GetItems([true, false], NumberOfBooleans);
    }
}
