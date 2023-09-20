using System.Runtime.CompilerServices;

namespace ConvertHexStringToByteArray.Library;

public static class ConversionHelpers
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int PerformModularArithmeticCalculation(char value) => (value % 32 + 9) % 25;

    public static byte[] FromHexWithModularArithmetic(ReadOnlySpan<char> source)
    {
        if (source.StartsWith("0x")) source = source[2..];

        if (source.IsEmpty) return Array.Empty<byte>();

        if (source.Length % 2 != 0) throw new ArgumentException("Invalid hex string", nameof(source));

        var dest = new byte[source.Length >> 1];
        for (int i = 0, j = 0; j < dest.Length; i += 2, j++)
            dest[j] = (byte) ((PerformModularArithmeticCalculation(source[i]) << 4) +
                PerformModularArithmeticCalculation(source[i + 1]));

        return dest;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static byte ComputeNibbleFromHexChar(char hexChar) =>
        hexChar switch
        {
            >= '0' and <= '9' => (byte) (hexChar - '0'),
            >= 'A' and <= 'F' => (byte) (hexChar - 'A' + 10),
            >= 'a' and <= 'f' => (byte) (hexChar - 'a' + 10),
            _ => throw new ArgumentException($"Invalid hex digit: '{hexChar}'", nameof(hexChar))
        };

    public static unsafe byte[] FromHexWithSwitchComputation(ReadOnlySpan<char> source)
    {
        if (source.StartsWith("0x")) source = source[2..];

        if (source.IsEmpty) return Array.Empty<byte>();

        if (source.Length % 2 != 0) throw new ArgumentException("Invalid hex string", nameof(source));

        var dest = new byte[source.Length >> 1];
        fixed (char* s = source)
        fixed (byte* d = dest)
        {
            var destPtr = d;
            var srcPtr = s;
            while (*srcPtr != 0)
            {
                var result = (byte) (ComputeNibbleFromHexChar(*srcPtr++) << 4);
                result |= ComputeNibbleFromHexChar(*srcPtr++);
                *destPtr++ = result;
            }
        }

        return dest;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int PerformBitManipulation(int value)
    {
        value -= 'A';

        return value + 10 + ((value >> 31) & 7);
    }

    public static unsafe byte[] FromHexWithBitManipulation(ReadOnlySpan<char> source)
    {
        if (source.StartsWith("0x")) source = source[2..];

        if (source.IsEmpty) return Array.Empty<byte>();

        if (source.Length % 2 != 0) throw new ArgumentException("Invalid hex string", nameof(source));

        var dest = new byte[source.Length >> 1];
        fixed (char* srcPtr = source)
        fixed (byte* destPtr = dest)
        {
            var sPtr = &srcPtr[0];
            var dPtr = &destPtr[0];
            while (*sPtr != 0)
            {
                var hi = PerformBitManipulation(*sPtr++);
                var lo = PerformBitManipulation(*sPtr++) & 0x0F;
                *dPtr++ = (byte) (lo | (hi << 4));
            }
        }

        return dest;
    }

    public static byte[] FromHexWithConvert(ReadOnlySpan<char> source)
    {
        if (source.StartsWith("0x")) source = source[2..];

        return Convert.FromHexString(source);
    }

    public static unsafe byte[] FromHexWithLookup(ReadOnlySpan<char> source)
    {
        if (source.StartsWith("0x")) source = source[2..];

        if (source.IsEmpty) return Array.Empty<byte>();

        if (source.Length % 2 == 1) throw new ArgumentException("Source has invalid length", nameof(source));

        var dest = new byte[source.Length >> 1];
        fixed (char* sourceRef = source)
        fixed (byte* hiRef = LookupTables.FromHexHighBitsLookup)
        fixed (byte* lowRef = LookupTables.FromHexLowBitsLookup)
        fixed (byte* destRef = dest)
        {
            var s = &sourceRef[0];
            var d = destRef;

            while (*s != 0)
            {
                byte lowValue;

                if (*s > 102 || (*d = hiRef[*s++]) == 255 ||
                    *s > 102 || (lowValue = lowRef[*s++]) == 255
                )
                    throw new ArgumentException($"Invalid character found in string: '{*s}'", nameof(source));

                *d++ += lowValue;
            }

            return dest;
        }
    }
}