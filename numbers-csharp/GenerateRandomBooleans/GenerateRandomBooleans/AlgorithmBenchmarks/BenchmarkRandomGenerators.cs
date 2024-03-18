using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using GenerateRandomBooleans.RandomGenerators;

namespace GenerateRandomBooleans.AlgorithmBenchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
public class BenchmarkRandomGenerators
{
    [Params(1_000, 1_000_000)]
    public int NumberOfIntegers { get; set; }

    public int[] Buffer { get; set; } = null!;

    [GlobalSetup]
    public void Setup()
    {
        Buffer = new int[NumberOfIntegers];
    }

    [Benchmark]
    public void SystemRandomGenerator()
    {
        var r = new SystemRandomGenerator();

        for (var index = 0; index < NumberOfIntegers; index++)
        {
            Buffer[index] = r.NextInteger(0, 2);
        }
    }

    [Benchmark]
    public void CryptographyRandomGenerator()
    {
        var r = new CryptographyRandomGenerator();

        for (var index = 0; index < NumberOfIntegers; index++)
        {
            Buffer[index] = r.NextInteger(0, 2);
        }
    }
}
