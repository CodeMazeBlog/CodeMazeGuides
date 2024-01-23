using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using GenerateRandomBooleans.BooleanGenerators;

namespace GenerateRandomBooleans.AlgorithmBenchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    public class BenchmarkNextBytesGeneratorVsNextIntegerBitsGenerator : BenchmarkBase
    {
        [Benchmark]
        [Arguments(1)]
        [Arguments(1_000)]
        [Arguments(1_000_000)]
        public void NextBytesGenerator(int numberOfBooleans)
        {
            var generator = new NextBytesGenerator(RandomGenerator, 128);
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
