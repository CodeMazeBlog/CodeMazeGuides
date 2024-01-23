using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using GenerateRandomBooleans.BooleanGenerators;
using GenerateRandomBooleans.RandomGenerators;

namespace GenerateRandomBooleans.AlgorithmBenchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    public class BenchmarkFirstThreePlusDirectGetItems : BenchmarkBase
    {
        [Benchmark]
        [Arguments(1)]
        [Arguments(1_000)]
        [Arguments(1_000_000)]
        public void NextIntegerGenerator(int numberOfBooleans)
        {
            var generator = new NextIntegerGenerator(RandomGenerator);
            StoreEverything(generator, numberOfBooleans);
        }

        [Benchmark]
        [Arguments(1)]
        [Arguments(1_000)]
        [Arguments(1_000_000)]
        public void NextDoubleGenerator(int numberOfBooleans)
        {
            var generator = new NextDoubleGenerator(RandomGenerator);
            StoreEverything(generator, numberOfBooleans);
        }

        [Benchmark]
        [Arguments(1)]
        [Arguments(1_000)]
        [Arguments(1_000_000)]
        public void GetItemsGenerator(int numberOfBooleans)
        {
            var generator = new GetItemsGenerator(RandomGenerator);
            StoreEverything(generator, numberOfBooleans);
        }

        [Benchmark]
        [Arguments(1)]
        [Arguments(1_000)]
        [Arguments(1_000_000)]
        public void GetItemsDirectGenerator(int numberOfBooleans)
        {
            var r = new SystemRandomGenerator();

            var _ = r.GetItems([true, false], numberOfBooleans);
        }
    }
}
