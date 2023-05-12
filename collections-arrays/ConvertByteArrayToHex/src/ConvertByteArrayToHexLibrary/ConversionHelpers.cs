using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using ConvertByteArrayHexLibrary;

namespace ConvertByteArrayToHexLibrary;

public static class ConversionHelpers
{
    public static string ToHexStringWithBitConverter(byte[] source, bool removeDashes = false)
    {
        if (source.Length == 0) return string.Empty;

        var result = BitConverter.ToString(source);

        return removeDashes ? result.Replace("-", string.Empty) : result;
    }

    public static string ToHexStringWithStringBuilderAppend(ReadOnlySpan<byte> source, bool lowerCase = false)
    {
        if (source.Length == 0) return string.Empty;

        var format = lowerCase ? "x2" : "X2";
        Span<char> temp = stackalloc char[64];

        var hex = new StringBuilder(source.Length * 2);
        var tempIndex = 0;
        ref var srcRef = ref MemoryMarshal.GetReference(source);
        for (var i = 0; i < source.Length; ++i)
        {
            var b = Unsafe.Add(ref srcRef, i);
            b.TryFormat(temp[tempIndex..(tempIndex + 2)], out _, format);

            tempIndex += 2;
            if (tempIndex - temp.Length == 0)
            {
                hex.Append(temp);
                tempIndex = 0;
            }
        }

        if (tempIndex > 0) hex.Append(temp[..tempIndex]);

        return hex.ToString();
    }

    public static unsafe string ToHexStringWithBitManipulation(byte[] source, bool lowerCase = false)
    {
        const int upperOffset = 'A' - 0xA;
        const int upperMask = -7;
        const int lowerOffset = 'a' - 0xA;
        const int lowerMask = -39;

        if (source.Length == 0) return string.Empty;

        var letterOffset = lowerCase ? lowerOffset : upperOffset;
        var letterMask = lowerCase ? lowerMask : upperMask;

        return string.Create(source.Length * 2, (Source: source, Offset: letterOffset, Mask: letterMask),
            (chars, args) =>
            {
                fixed (byte* sPtr = args.Source)
                fixed (char* destPtrFixed = &MemoryMarshal.GetReference(chars))
                {
                    var destPtr = destPtrFixed;
                    var srcPtr = sPtr;
                    for (var i = 0; i < args.Source.Length; ++i)
                    {
                        var item = *srcPtr++;
                        var highNibble = item >> 4;
                        var lowNibble = item & 0xF;

                        *destPtr++ = (char) (args.Offset + highNibble + (((highNibble - 10) >> 31) & args.Mask));
                        *destPtr++ = (char) (args.Offset + lowNibble + (((lowNibble - 10) >> 31) & args.Mask));
                    }
                }
            });
    }

    public static string ToHexStringWithAlphabetSpanLookup(byte[] source, bool lowerCase = false)
    {
        if (source.Length == 0) return string.Empty;

        return string.Create(source.Length * 2, (Source: source, LowerCase: lowerCase), (chars, args) =>
        {
            ref var sPtr = ref MemoryMarshal.GetArrayDataReference(args.Source);
            ref var hexSpan = ref MemoryMarshal.GetReference(LookupTables.GetAlphabetSpan(args.LowerCase));
            ref var destPtr = ref MemoryMarshal.GetReference(chars);
            for (var i = 0; i < args.Source.Length; ++i)
            {
                var b = Unsafe.Add(ref sPtr, i);
                destPtr = (char) Unsafe.Add(ref hexSpan, b >> 4);
                destPtr = ref Unsafe.Add(ref destPtr, 1);
                destPtr = (char) Unsafe.Add(ref hexSpan, b & 0xF);
                destPtr = ref Unsafe.Add(ref destPtr, 1);
            }
        });
    }

    public static string ToHexStringWithLookup(byte[] source, bool lowerCase = false)
    {
        if (source.Length == 0) return string.Empty;

        return string.Create(source.Length * 2, (Source: source, LowerCase: lowerCase), (chars, args) =>
        {
            ref var sPtr = ref MemoryMarshal.GetArrayDataReference(args.Source);
            ref var lookupTable = ref MemoryMarshal.GetArrayDataReference(LookupTables.GetLookupTable(args.LowerCase));
            ref var cPtr = ref MemoryMarshal.GetReference(chars);
            for (var i = 0; i < args.Source.Length; ++i)
            {
                var b = Unsafe.Add(ref sPtr, i);
                Unsafe.As<char, uint>(ref cPtr) = Unsafe.Add(ref lookupTable, b);
                cPtr = ref Unsafe.Add(ref cPtr, 2);
            }
        });
    }

    public static unsafe string ToHexStringWithLookupNetStandard20(byte[] source, bool lowerCase = false)
    {
        if (source.Length == 0) return string.Empty;

        var dest = new string(' ', source.Length * 2);
        fixed (byte* bPtr = source)
        fixed (char* dPtr = dest)
        fixed (uint* lookupRef = LookupTables.GetLookupTable(lowerCase))
        {
            var src = bPtr;
            var destPtr = (uint*) dPtr;
            for (var i = 0; i < source.Length; ++i) *destPtr++ = lookupRef[*src++];
        }

        return dest;
    }

    public static string ToHexStringWithConvert(ReadOnlySpan<byte> source, bool lowerCase = false)
    {
        var result = Convert.ToHexString(source);

        return lowerCase ? result.ToLowerInvariant() : result;
    }
}