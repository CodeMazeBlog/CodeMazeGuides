using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using GenerateRandomBooleans.BooleanGenerators;

namespace GenerateRandomBooleans.AlgorithmBenchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    public class BenchmarkNextIntegerBitsGeneratorVsNextLongBitsGenerator : BenchmarkBase
    {
        [Benchmark(Baseline = true)]
        [Arguments(1)]
        [Arguments(1_000)]
        [Arguments(1_000_000)]
        public long NextIntegerBitsGenerator(int numberOfBooleans)
        {
            var generator = new NextIntegerBitsGenerator(RandomGenerator);

            return RoundRobin(generator, numberOfBooleans);
        }

        [Benchmark]
        [Arguments(1)]
        [Arguments(1_000)]
        [Arguments(1_000_000)]
        public long NextLongBitsGenerator(int numberOfBooleans)
        {
            var generator = new NextLongBitsGenerator(RandomGenerator);

            return RoundRobin(generator, numberOfBooleans);
        }
    }
}
