using System.Runtime.InteropServices;
using System;

namespace ByteRepresentationOfStrings;

public class StringByteConverter
{
    public static byte[] GetBytes(string str)
    {
        var bytes = new byte[str.Length * sizeof(char)];
        Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
        return bytes;
    }

    public static string GetString(byte[] bytes)
    {
        var chars = new char[bytes.Length / sizeof(char)];
        Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
        return new string(chars);
    }

    // Modern version using Span
    public static byte[] GetBytesWithSpan(ReadOnlySpan<char> charSpan)
    {
        ReadOnlySpan<byte> byteSpan = MemoryMarshal.AsBytes(charSpan);

        var bytes = new byte[byteSpan.Length];
        byteSpan.CopyTo(bytes);

        return bytes;
    }

    public static string GetStringWithSpan(byte[] bytes)
    {
        Span<char> charsSpan = MemoryMarshal.Cast<byte, char>(bytes);
        return new string(charsSpan);
    }
}