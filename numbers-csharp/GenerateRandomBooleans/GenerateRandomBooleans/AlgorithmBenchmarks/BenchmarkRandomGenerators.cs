using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using GenerateRandomBooleans.RandomGenerators;

namespace GenerateRandomBooleans.AlgorithmBenchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
    public class BenchmarkRandomGenerators
    {
        [Benchmark]
        [Arguments(1)]
        [Arguments(1_000)]
        [Arguments(1_000_000)]
        public void SystemRandomGenerator(int numberOfIntegers)
        {
            var r = new SystemRandomGenerator();
            var result = new int[numberOfIntegers];

            for (var index = 0; index < numberOfIntegers; index++)
            {
                result[index] = r.NextInteger(0, 2);
            }
        }

        [Benchmark]
        [Arguments(1)]
        [Arguments(1_000)]
        [Arguments(1_000_000)]
        public void CryptographyRandomGenerator(int numberOfIntegers)
        {
            var r = new CryptographyRandomGenerator();
            var result = new int[numberOfIntegers];

            for (var index = 0; index < numberOfIntegers; index++)
            {
                result[index] = r.NextInteger(0, 2);
            }
        }
    }
}
