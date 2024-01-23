using System.Security.Cryptography;

namespace GenerateRandomBooleans.RandomGenerators
{
    public class CryptographyRandomGenerator : IRandomGenerator
    {
        private readonly RandomNumberGenerator _random = RandomNumberGenerator.Create();

        public int NextInteger(int fromInclusive, int toExclusive) => RandomNumberGenerator.GetInt32(fromInclusive, toExclusive);

        public long NextLong(long fromInclusive, long toExclusive) => throw new System.NotImplementedException();

        public double NextDouble() => throw new System.NotImplementedException();

        public T[] GetItems<T>(T[] choices, int length)
        {
            ReadOnlySpan<T> choicesSpan = choices;

            return RandomNumberGenerator.GetItems(choicesSpan, length);
        }

        public void NextBytes(byte[] buffer) => _random.GetBytes(buffer);
    }
}
