using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using ConvertByteArrayHexLibrary;

namespace ConvertByteArrayToHexLibrary;

public static class ConversionHelpers
{
    public static string ToHexWithBitConverter(byte[] source, bool removeDashes = false)
    {
        if (source.Length == 0) return string.Empty;

        var result = BitConverter.ToString(source);

        return removeDashes ? result.Replace("-", string.Empty) : result;
    }

    public static string ToHexWithStringBuilderAppend(ReadOnlySpan<byte> source, bool lowercase = false)
    {
        if (source.Length == 0) return string.Empty;

        var format = lowercase ? "x2" : "X2";
        Span<char> buffer = stackalloc char[64];

        var sb = new StringBuilder(source.Length * 2);
        var bufferIndex = 0;
        ref var srcRef = ref MemoryMarshal.GetReference(source);
        for (var i = 0; i < source.Length; ++i)
        {
            var b = Unsafe.Add(ref srcRef, i);
            b.TryFormat(buffer.Slice(bufferIndex, 2), out _, format);
            bufferIndex += 2;
            if (bufferIndex == buffer.Length)
            {
                sb.Append(buffer);
                bufferIndex = 0;
            }
        }

        if (bufferIndex > 0) sb.Append(buffer[..bufferIndex]);

        return sb.ToString();
    }

    public static string ToHexWithTryFormatAndStringCreate(byte[] source, bool lowercase = false)
    {
        if (source.Length == 0) return string.Empty;

        return string.Create(source.Length * 2,
            (Source: source, Lowercase: lowercase),
            (chars, args) =>
            {
                var format = args.Lowercase ? "x2" : "X2";
                ref var srcPtr = ref MemoryMarshal.GetArrayDataReference(args.Source);
                var destIndex = 0;
                for (var i = 0; i < source.Length; ++i)
                {
                    var b = Unsafe.Add(ref srcPtr, i);
                    b.TryFormat(chars[destIndex..], out _, format);
                    destIndex += 2;
                }
            });
    }

    public static string ToHexWithBitManipulation(byte[] source, bool lowercase = false)
    {
        const int upperOffset = 'A' - 0xA;
        const int lowerOffset = 'a' - 0xA;

        if (source.Length == 0) return string.Empty;

        var letterOffset = lowercase ? lowerOffset : upperOffset;
        var digitOffset = '0' - letterOffset;

        return string.Create(source.Length * 2,
            (Source: source, LetterOffset: letterOffset, DigitOffset: digitOffset),
            (chars, args) =>
            {
                ref var srcPtr = ref MemoryMarshal.GetArrayDataReference(args.Source);
                ref var destPtr = ref MemoryMarshal.GetReference(chars);
                for (var i = 0; i < args.Source.Length; ++i)
                {
                    var b = Unsafe.Add(ref srcPtr, i);

                    destPtr = ComputeCharFromNibble(b >> 4, args.LetterOffset, args.DigitOffset);
                    destPtr = ref Unsafe.Add(ref destPtr, 1);
                    destPtr = ComputeCharFromNibble(b & 0xF, args.LetterOffset, args.DigitOffset);
                    destPtr = ref Unsafe.Add(ref destPtr, 1);
                }
            });

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static char ComputeCharFromNibble(int nibble, int letterOffset, int digitOffset)
        {
            var digitCalculation = ((nibble - 10) >> 31) & digitOffset;

            return (char) (letterOffset + nibble + digitCalculation);
        }
    }

    public static string ToHexWithAlphabetSpanLookup(byte[] source, bool lowercase = false)
    {
        if (source.Length == 0) return string.Empty;

        return string.Create(source.Length * 2,
            (Source: source, Lowercase: lowercase),
            (chars, args) =>
            {
                ref var srcPtr = ref MemoryMarshal.GetArrayDataReference(args.Source);
                ref var hexSpan = ref MemoryMarshal.GetReference(LookupTables.GetAlphabetSpan(args.Lowercase));
                ref var destPtr = ref MemoryMarshal.GetReference(chars);
                for (var i = 0; i < args.Source.Length; ++i)
                {
                    var b = Unsafe.Add(ref srcPtr, i);
                    destPtr = (char)Unsafe.Add(ref hexSpan, b >> 4);
                    destPtr = ref Unsafe.Add(ref destPtr, 1);
                    destPtr = (char)Unsafe.Add(ref hexSpan, b & 0xF);
                    destPtr = ref Unsafe.Add(ref destPtr, 1);
                }
            });
    }

    public static string ToHexWithLookup(byte[] source, bool lowercase = false)
    {
        if (source.Length == 0) return string.Empty;

        return string.Create(source.Length * 2,
            (Source: source, Lowercase: lowercase),
            (chars, args) =>
            {
                ref var sPtr = ref MemoryMarshal.GetArrayDataReference(args.Source);
                ref var lookupTable = ref MemoryMarshal.GetArrayDataReference(LookupTables.GetLookupTable(args.Lowercase));
                ref var cPtr = ref MemoryMarshal.GetReference(chars);
                for (var i = 0; i < args.Source.Length; ++i)
                {
                    var b = Unsafe.Add(ref sPtr, i);
                    Unsafe.As<char, uint>(ref cPtr) = Unsafe.Add(ref lookupTable, b);
                    cPtr = ref Unsafe.Add(ref cPtr, 2);
                }
            });
    }

    public static unsafe string ToHexWithLookupNetStandard20(byte[] source, bool lowercase = false)
    {
        if (source.Length == 0) return string.Empty;

        var dest = new string('\0', source.Length * 2);
        fixed (byte* bPtr = source)
        fixed (char* dPtr = dest)
        fixed (uint* lookupRef = LookupTables.GetLookupTable(lowercase))
        {
            var src = bPtr;
            var destPtr = (uint*) dPtr;
            for (var i = 0; i < source.Length; ++i) *destPtr++ = lookupRef[*src++];
        }

        return dest;
    }

    public static string ToHexWithConvert(ReadOnlySpan<byte> source, bool lowercase = false)
    {
        var result = Convert.ToHexString(source);

        return lowercase ? result.ToLowerInvariant() : result;
    }
}