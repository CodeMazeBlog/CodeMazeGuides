using System.Runtime.CompilerServices;

namespace ConvertHexStringToByteArray.Library;

public static class ConversionHelpers
{
    public static unsafe byte[] FromHexWithLookup(ReadOnlySpan<char> source)
    {
        if (source.StartsWith("0x")) source = source[2..];
        if (source.Length == 0) return Array.Empty<byte>();
        if (source.Length % 2 == 1) throw new ArgumentException("Source has invalid length", nameof(source));

        var destLength = source.Length >> 1; 

        fixed (char* sourceRef = source)
        {
            var firstChar = 0;
            var dest = GC.AllocateUninitializedArray<byte>(destLength);

            // Pin the lookups and the destination
            fixed (byte* hiRef = LookupTables.FromHex16Lookup)
            fixed (byte* lowRef = LookupTables.FromHexLookup)
            fixed (byte* destRef = dest)
            {
                // Get incrementable reference to the source and the destination
                var s = &sourceRef[firstChar];
                var d = destRef;

                // Walk through the source, computing the destination entries
                while (*s != 0)
                {
                    // check for non valid characters in pairs
                    Unsafe.SkipInit(out byte lowValue);
                    if (*s > 102 || (*d = hiRef[*s++]) == 255 ||
                        *s > 102 || (lowValue = lowRef[*s++]) == 255
                       )
                        throw new ArgumentException($"Invalid character found in string: '{*s}'", nameof(source));

                    // set final value of current result byte and move pointer to next byte
                    *d++ += lowValue;
                }

                return dest;
            }
        }
    }

    public static byte[] FromHexWithConvert(ReadOnlySpan<char> source)
    {
        if (source.StartsWith("0x")) source = source[2..];
        return Convert.FromHexString(source);
    }

    public static unsafe byte[] FromHexWithBitFiddle(ReadOnlySpan<char> source)
    {
        if (source.Length == 0) return Array.Empty<byte>();

        if (source.StartsWith("0x")) source = source[2..];
        if (source.IsEmpty || source.Length % 2 != 0) throw new ArgumentException("Invalid hex string", nameof(source));
        var dest = GC.AllocateUninitializedArray<byte>(source.Length / 2);
        fixed (char* srcPtr = source)
        fixed (byte* destPtr = dest)
        {
            unchecked
            {
                for (int i = 0; i < dest.Length; ++i)
                {
                    int hi = srcPtr[i * 2] - 65;
                    hi = hi + 10 + ((hi >> 31) & 7);

                    int lo = srcPtr[i * 2 + 1] - 65;
                    lo = (lo + 10 + ((lo >> 31) & 7)) & 0x0f;

                    destPtr[i] = (byte) (lo | (hi << 4));
                }
            }
        }

        return dest;
    }

    public static unsafe byte[] FromHexWithSwitchComputation(ReadOnlySpan<char> source)
    {
        if (source.Length == 0) return Array.Empty<byte>();

        if (source.StartsWith("0x")) source = source[2..];
        if (source.IsEmpty || source.Length % 2 != 0) throw new ArgumentException("Invalid hex string", nameof(source));

        var dest = GC.AllocateUninitializedArray<byte>(source.Length / 2);
        fixed(char* s = source)
        fixed (byte* d = dest)
        {
            var destPtr = d;
            var srcPtr = s;
            while (*srcPtr != 0)
            {
                var result = (byte)(ComputeNibbleFromHexChar(*srcPtr++) << 4);
                result |= ComputeNibbleFromHexChar(*srcPtr++);
                *destPtr++ = result;
            }
        }

        return dest;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static byte ComputeNibbleFromHexChar(char hexChar) =>
        hexChar switch
        {
            >= '0' and <= '9' => (byte)(hexChar - '0'),
            >= 'a' and <= 'f' => (byte)(hexChar - 'a' + 10),
            >= 'A' and <= 'F' => (byte)(hexChar - 'A' + 10),
            _ => throw new ArgumentException($"Invalid hex digit: '{hexChar}'", nameof(hexChar)),
        };
}