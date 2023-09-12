using BenchmarkDotNet.Attributes;

namespace App;

public class RandomNumberBenchmarks
{
    [Benchmark]
    public int UsingRealRandomNumberGenerator() => CryptographicHelpers.GenerateRandomInteger(1, 100);
    
    [Benchmark]
    public int UsingPseudoRandomNumberGenerator() => CryptographicHelpers.GeneratePseudoRandom(1, 100);
}