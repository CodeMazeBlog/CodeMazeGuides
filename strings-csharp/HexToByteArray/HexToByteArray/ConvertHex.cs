using System.Runtime.CompilerServices;

namespace HexToByteArray
{
    public static class ConvertHex
    {
        public static byte[] FromHexString(ReadOnlySpan<char> hex)
        {
            return Convert.FromHexString(hex);
        }

        public static byte[] FromHexWithCharacterWiseTranslation(ReadOnlySpan<char> hex)
        {
            int length = hex.Length;
            byte[] bytes = GC.AllocateUninitializedArray<byte>(length >> 1);
            for (int i = 0; i < length; i += 2)
                bytes[i >> 1] = byte.Parse(hex.Slice(i, 2),
                    System.Globalization.NumberStyles.HexNumber);
            return bytes;
        }

        public static byte[] FromHexWithPointers(string hex)
        {
            if (hex.Length % 2 != 0) throw new ArgumentException("Invalid hex string", nameof(hex));

            var res = new byte[hex.Length / 2]; // Allocate memory
            for (int i = 0, j = 0; j < res.Length; i += 2, j++) // Conversion loop
            {
                var firstChar = (byte)((hex[i] % 32 + 9) % 25);
                var secondChar = (byte)((hex[i + 1] % 32 + 9) % 25);
                res[j] = (byte)(firstChar * 16 + secondChar);
            }
            return res;
        }

        public static unsafe byte[] FromHexWithSwitchComputation(ReadOnlySpan<char> source)
        {
            if (source.StartsWith("0x")) source = source[2..];

            if (source.IsEmpty) return Array.Empty<byte>();

            if (source.Length % 2 != 0) throw new ArgumentException("Invalid hex string", nameof(source));

            var dest = GC.AllocateUninitializedArray<byte>(source.Length >> 1);
            fixed (char* s = source)
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
            _ => throw new ArgumentException($"Invalid hex digit: '{hexChar}'", nameof(hexChar))
        };

        public static unsafe byte[] FromHexWithBitFiddle(ReadOnlySpan<char> source)
        {
            if (source.StartsWith("0x")) source = source[2..];

            if (source.IsEmpty) return Array.Empty<byte>();

            if (source.Length % 2 != 0) throw new ArgumentException("Invalid hex string", nameof(source));

            var dest = GC.AllocateUninitializedArray<byte>(source.Length >> 1);
            fixed (char* srcPtr = source)
            fixed (byte* destPtr = dest)
            {
                var sPtr = &srcPtr[0];
                var dPtr = &destPtr[0];
                unchecked
                {
                    while (*sPtr != 0)
                    {
                        var hi = PerformBitFiddleCalculation(*sPtr++);
                        var lo = PerformBitFiddleCalculation(*sPtr++) & 0x0F;

                        *dPtr++ = (byte)(lo | (hi << 4));
                    }
                }
            }

            return dest;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int PerformBitFiddleCalculation(int value)
        {
            value -= 65;

            return value + 10 + ((value >> 31) & 7);
        }

        public static unsafe byte[] FromHexWithLookup(ReadOnlySpan<char> source)
        {
            if (source.StartsWith("0x")) source = source[2..];

            if (source.IsEmpty) return Array.Empty<byte>();

            if (source.Length % 2 == 1) throw new ArgumentException("Source has invalid length", nameof(source));

            var dest = GC.AllocateUninitializedArray<byte>(source.Length >> 1);
            fixed (char* sourceRef = source)
            fixed (byte* hiRef = LookupTables.FromHexHighBitsLookup)
            fixed (byte* lowRef = LookupTables.FromHexLowBitsLookup)
            fixed (byte* destRef = dest)
            {
                var s = &sourceRef[0];
                var d = destRef;

                while (*s != 0)
                {
                    Unsafe.SkipInit(out byte lowValue);

                    if (*s > 102 || (*d = hiRef[*s++]) == 255 ||
                        *s > 102 || (lowValue = lowRef[*s++]) == 255
                    )
                        throw new ArgumentException($"Invalid character found in string: '{*s}'", nameof(source));

                    *d++ += lowValue;
                }

                return dest;
            }
        }

        class LookupTables
        {
            internal static ReadOnlySpan<byte> FromHexLowBitsLookup => new byte[]
            {
                255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
                255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
                255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
                255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
                255, 255, 255, 255, 255, 255, 255, 255, 0, 1,
                2, 3, 4, 5, 6, 7, 8, 9, 255, 255,
                255, 255, 255, 255, 255, 10, 11, 12, 13, 14,
                15, 255, 255, 255, 255, 255, 255, 255, 255, 255,
                255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
                255, 255, 255, 255, 255, 255, 255, 10, 11, 12,
                13, 14, 15
            };

            internal static ReadOnlySpan<byte> FromHexHighBitsLookup => new byte[]
            {
                255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
                255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
                255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
                255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
                255, 255, 255, 255, 255, 255, 255, 255, 0, 16,
                32, 48, 64, 80, 96, 112, 128, 144, 255, 255,
                255, 255, 255, 255, 255, 160, 176, 192, 208, 224,
                240, 255, 255, 255, 255, 255, 255, 255, 255, 255,
                255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
                255, 255, 255, 255, 255, 255, 255, 160, 176, 192,
                208, 224, 240
            };
        }
    }
}
