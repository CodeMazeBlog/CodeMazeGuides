using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Tests;

internal sealed class MockRandomGenerator(Span<bool> bufferItems, Span<byte> sourceBytes) : IRandomGenerator
{
    private readonly bool[] _bufferItems = bufferItems.ToArray();
    private readonly byte[] _sourceBytes = sourceBytes.ToArray();

    public int NextInteger(int fromInclusive, int toExclusive) => throw new NotImplementedException();

    public long NextLong(long fromInclusive, long toExclusive) => throw new NotImplementedException();

    public double NextDouble() => throw new NotImplementedException();

    public void GetItems<T>(ReadOnlySpan<T> choices, Span<T> destination)
    {
        if (typeof(T) == typeof(bool))
        {
            var bufferSpan = _bufferItems.AsSpan();
            var dest = MemoryMarshal.CreateSpan(ref Unsafe.As<T, bool>(ref MemoryMarshal.GetReference(destination)),
                destination.Length);
            if (dest.Length < bufferSpan.Length)
            {
                bufferSpan = bufferSpan[..dest.Length];
            }

            bufferSpan.CopyTo(dest);
        }
        else
        {
            throw new NotImplementedException();
        }
    }

    public void NextBytes(Span<byte> buffer)
    {
        var sourceSpan = _sourceBytes.AsSpan();
        if (buffer.Length < sourceSpan.Length)
        {
            sourceSpan = sourceSpan[..buffer.Length];
        }

        sourceSpan.CopyTo(buffer);
    }
}