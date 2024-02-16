
using System.Runtime.CompilerServices;

namespace GenerateRandomBooleans.RandomGenerators
{
    public class SystemRandomGenerator : IRandomGenerator
    {
        private readonly Random _random = new();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int NextInteger(int fromInclusive, int toExclusive) => _random.Next(fromInclusive, toExclusive);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long NextLong(long fromInclusive, long toExclusive) => _random.NextInt64(fromInclusive, toExclusive);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double NextDouble() => _random.NextDouble();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void GetItems<T>(ReadOnlySpan<T> choices, Span<T> result) => _random.GetItems(choices, result);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void NextBytes(Span<byte> buffer) => _random.NextBytes(buffer);
    }
}
