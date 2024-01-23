namespace GenerateRandomBooleans.RandomGenerators
{
    public interface IRandomGenerator
    {
        int NextInteger(int fromInclusive, int toExclusive);

        long NextLong(long fromInclusive, long toExclusive);

        double NextDouble();

        T[] GetItems<T>(T[] choices, int length);

        void NextBytes(byte[] buffer);
    }
}
