using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using GenerateRandomBooleans.BooleanGenerators;

namespace GenerateRandomBooleans.AlgorithmBenchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    public class BenchmarkNextIntegerBitsGeneratorVsNextIntegerGenerator : BenchmarkBase
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
        public void NextIntegerBitsGenerator(int numberOfBooleans)
        {
            var generator = new NextIntegerBitsGenerator(RandomGenerator);
            RoundRobin(generator, numberOfBooleans);
        }
    }
}
