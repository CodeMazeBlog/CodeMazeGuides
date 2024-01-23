using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using GenerateRandomBooleans.BooleanGenerators;

namespace GenerateRandomBooleans.AlgorithmBenchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    public class BenchmarkFirstThreeGenerators : BenchmarkBase
    {
        [Benchmark]
        [Arguments(1)]
        [Arguments(1_000)]
        [Arguments(1_000_000)]
        public void NextIntegerGenerator(int numberOfBooleans)
        {
            var generator = new NextIntegerGenerator(RandomGenerator);
            RoundRobin(generator, numberOfBooleans);
        }

        [Benchmark]
        [Arguments(1)]
        [Arguments(1_000)]
        [Arguments(1_000_000)]
        public void NextDoubleGenerator(int numberOfBooleans)
        {
            var generator = new NextDoubleGenerator(RandomGenerator);
            RoundRobin(generator, numberOfBooleans);
        }

        [Benchmark]
        [Arguments(1)]
        [Arguments(1_000)]
        [Arguments(1_000_000)]
        public void GetItemsGenerator(int numberOfBooleans)
        {
            var generator = new GetItemsGenerator(RandomGenerator);
            RoundRobin(generator, numberOfBooleans);
        }
    }
}
