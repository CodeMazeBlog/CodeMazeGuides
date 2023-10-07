namespace ConvertHexStringToByteArray.Library;

public static class LookupTables
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

    public static (byte[] lowBits, byte[] highBits) CreateLookups()
    {
        const string hexValues = "0123456789ABCDEFabcdef";

        var lowBits = new byte['f' + 1];
        var highBits = new byte['f' + 1];
        Array.Fill(lowBits, (byte) 255);
        Array.Fill(highBits, (byte) 255);

        foreach (var c in hexValues.AsSpan())
        {
            var value = ConversionHelpers.ComputeNibbleFromHexChar(c);
            lowBits[c] = value;
            highBits[c] = (byte) (value << 4);
        }

        return (lowBits, highBits);
    }
}