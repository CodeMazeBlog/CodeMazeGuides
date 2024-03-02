namespace GenerateRandomBooleans.RandomGenerators;

public interface IRandomGenerator
{
    int NextInteger(int fromInclusive, int toExclusive);

    long NextLong(long fromInclusive, long toExclusive);

    double NextDouble();

    void GetItems<T>(ReadOnlySpan<T> choices, Span<T> destination);
}
