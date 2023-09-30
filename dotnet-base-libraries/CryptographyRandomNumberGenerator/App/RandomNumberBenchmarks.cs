using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace App;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class RandomNumberBenchmarks
{
    [Benchmark]
    public int UsingCryptoSecureRandomNumberGenerator() => CryptographicHelpers.GenerateSecureRandomInteger(1, 100);

    [Benchmark]
    public int UsingGeneralRandomNumberGenerator() => CryptographicHelpers.GenerateGeneralRandomInteger(1, 100);
}