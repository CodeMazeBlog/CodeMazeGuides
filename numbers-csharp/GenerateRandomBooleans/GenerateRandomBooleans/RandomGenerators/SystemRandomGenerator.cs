namespace GenerateRandomBooleans.RandomGenerators;

public class SystemRandomGenerator : IRandomGenerator
{
    private readonly Random _random = new();

    public int NextInteger(int fromInclusive, int toExclusive) => _random.Next(fromInclusive, toExclusive);

    public long NextLong(long fromInclusive, long toExclusive) => _random.NextInt64(fromInclusive, toExclusive);

    public double NextDouble() => _random.NextDouble();

    public T[] GetItems<T>(T[] choices, int length) => _random.GetItems(choices, length);

    public void NextBytes(byte[] buffer) => _random.NextBytes(buffer);
}
