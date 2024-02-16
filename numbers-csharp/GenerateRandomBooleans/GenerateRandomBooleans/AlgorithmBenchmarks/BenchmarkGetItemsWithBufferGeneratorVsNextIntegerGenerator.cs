using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using GenerateRandomBooleans.BooleanGenerators;

namespace GenerateRandomBooleans.AlgorithmBenchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    public class BenchmarkGetItemsWithBufferGeneratorVsNextIntegerGenerator : BenchmarkBase
    {
        [Benchmark]
        [Arguments(1)]
        [Arguments(1_000)]
        [Arguments(1_000_000)]
        public long NextIntegerGenerator(int numberOfBooleans)
        {
            var generator = new NextIntegerGenerator(RandomGenerator);

            return RoundRobin(generator, numberOfBooleans);
        }

        [Benchmark]
        [Arguments(1)]
        [Arguments(1_000)]
        [Arguments(1_000_000)]
        public long GetItemsWithBufferGenerator(int numberOfBooleans)
        {
            var generator = new GetItemsWithBufferGenerator(RandomGenerator, 128);

            return RoundRobin(generator, numberOfBooleans);
        }
    }
}
