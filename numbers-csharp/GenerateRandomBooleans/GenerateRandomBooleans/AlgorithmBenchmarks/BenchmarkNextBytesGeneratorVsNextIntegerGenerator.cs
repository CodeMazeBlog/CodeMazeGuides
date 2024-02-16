using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using GenerateRandomBooleans.BooleanGenerators;

namespace GenerateRandomBooleans.AlgorithmBenchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    public class BenchmarkNextBytesGeneratorVsNextIntegerGenerator : BenchmarkBase
    {
        private readonly int NumberOfBooleans = 1_000_000;

        [Benchmark]
        [Arguments(4)]
        [Arguments(32)]
        [Arguments(64)]
        [Arguments(128)]
        [Arguments(256)]
        [Arguments(1024)]
        public long NextBytesGenerator(int bufferSize)
        {
            var generator = new NextBytesGenerator(RandomGenerator, bufferSize);

            return RoundRobin(generator, NumberOfBooleans);
        }
    }
}
