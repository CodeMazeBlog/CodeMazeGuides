using BenchmarkDotNet.Attributes;

namespace App;

public class RandomNumberBenchmarks
{
    [Benchmark]
    public void UsingRealRandomNumberGenerator()
    {
        var randomNumber = CryptographicHelpers.GenerateRandomInteger(1, 100);
    }
    
    [Benchmark]
    public void UsingPseudoRandomNumberGenerator()
    {
        var randomNumber = CryptographicHelpers.GeneratePseudoRandom(1, 100);
    }   
}
