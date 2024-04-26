using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace GenerateRandomBooleans.RandomGenerators;

public sealed class CryptographyRandomGenerator : IRandomGenerator, IDisposable
{
    private readonly RandomNumberGenerator _random = RandomNumberGenerator.Create();

    public int NextInteger(int fromInclusive, int toExclusive) => RandomNumberGenerator.GetInt32(fromInclusive, toExclusive);

    public long NextLong(long fromInclusive, long toExclusive) => throw new System.NotImplementedException();

    public double NextDouble() => throw new System.NotImplementedException();

    public void GetItems<T>(ReadOnlySpan<T> choices, Span<T> result) => RandomNumberGenerator.GetItems(choices, result);

    public void Dispose()
    {
        _random.Dispose();
    }
}
