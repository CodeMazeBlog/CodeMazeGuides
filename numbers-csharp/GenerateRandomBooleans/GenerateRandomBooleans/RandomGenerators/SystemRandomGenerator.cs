using System.Runtime.CompilerServices;

namespace GenerateRandomBooleans.RandomGenerators;

public class SystemRandomGenerator : IRandomGenerator
{
    private readonly Random _random = new();

    public int NextInteger(int fromInclusive, int toExclusive) => _random.Next(fromInclusive, toExclusive);

    public long NextLong(long fromInclusive, long toExclusive) => _random.NextInt64(fromInclusive, toExclusive);

    public double NextDouble() => _random.NextDouble();

    public void GetItems<T>(ReadOnlySpan<T> choices, Span<T> result) => _random.GetItems(choices, result);
}
