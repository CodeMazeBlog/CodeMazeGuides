using System.Runtime.CompilerServices;

namespace ConvertHexStringToByteArray.Library;

public static class ConversionHelpers
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int PerformModularArithmeticCalculation(char value) => (value % 32 + 9) % 25;

    public static byte[] FromHexWithModularArithmetic(ReadOnlySpan<char> input)
    {
        if (input.Length % 2 != 0)
            throw new ArgumentException("Input has invalid length", nameof(input));

        if (input.StartsWith("0x"))
            input = input[2..];

        if (input.IsEmpty)
            return Array.Empty<byte>();

        var dest = new byte[input.Length >> 1];
        for (int i = 0, j = 0; j < dest.Length; j++)
            dest[j] = (byte)((PerformModularArithmeticCalculation(input[i++]) << 4) +
                PerformModularArithmeticCalculation(input[i++]));

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

    public static unsafe byte[] FromHexWithSwitchComputation(ReadOnlySpan<char> input)
    {
        if (input.Length % 2 != 0)
            throw new ArgumentException("Input has invalid length", nameof(input));

        if (input.StartsWith("0x"))
            input = input[2..];

        if (input.IsEmpty)
            return Array.Empty<byte>();

        var dest = new byte[input.Length >> 1];
        fixed (char* s = input)
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
    private static int PerformBitManipulation(int charValue)
    {
        charValue -= 'A';

        return charValue + 10 + ((charValue >> 31) & 7);
    }

    public static unsafe byte[] FromHexWithBitManipulation(ReadOnlySpan<char> input)
    {
        if (input.Length % 2 != 0)
            throw new ArgumentException("Input has invalid length", nameof(input));

        if (input.StartsWith("0x"))
            input = input[2..];

        if (input.IsEmpty)
            return Array.Empty<byte>();

        var dest = new byte[input.Length >> 1];
        fixed (char* srcPtr = input)
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

    public static byte[] FromHexWithConvert(ReadOnlySpan<char> input)
    {
        if (input.StartsWith("0x"))
            input = input[2..];

        return Convert.FromHexString(input);
    }

    public static unsafe byte[] FromHexWithLookup(ReadOnlySpan<char> input)
    {
        if (input.Length % 2 != 0)
            throw new ArgumentException("Input has invalid length", nameof(input));

        if (input.StartsWith("0x"))
            input = input[2..];

        if (input.IsEmpty)
            return Array.Empty<byte>();

        var dest = new byte[input.Length >> 1];
        fixed (char* inputRef = input)
        fixed (byte* hiRef = LookupTables.FromHexHighBitsLookup)
        fixed (byte* lowRef = LookupTables.FromHexLowBitsLookup)
        fixed (byte* destRef = dest)
        {
            var s = &inputRef[0];
            var d = destRef;

            while (*s != 0)
            {
                byte lowValue;

                if (*s > 102 || (*d = hiRef[*s++]) == 255 ||
                    *s > 102 || (lowValue = lowRef[*s++]) == 255 )
                    throw new ArgumentException($"Invalid character found in string: '{*s}'", nameof(input));

                *d++ += lowValue;
            }

            return dest;
        }
    }
}