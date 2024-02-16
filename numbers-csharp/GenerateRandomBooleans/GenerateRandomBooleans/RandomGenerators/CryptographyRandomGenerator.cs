using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace GenerateRandomBooleans.RandomGenerators
{
    public sealed class CryptographyRandomGenerator : IRandomGenerator, IDisposable
    {
        private readonly RandomNumberGenerator _random = RandomNumberGenerator.Create();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int NextInteger(int fromInclusive, int toExclusive) => RandomNumberGenerator.GetInt32(fromInclusive, toExclusive);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long NextLong(long fromInclusive, long toExclusive) => throw new System.NotImplementedException();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double NextDouble() => throw new System.NotImplementedException();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void GetItems<T>(ReadOnlySpan<T> choices, Span<T> result) => RandomNumberGenerator.GetItems(choices, result);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void NextBytes(Span<byte> buffer) => _random.GetBytes(buffer);

        public void Dispose()
        {
            _random.Dispose();
        }
    }
}
