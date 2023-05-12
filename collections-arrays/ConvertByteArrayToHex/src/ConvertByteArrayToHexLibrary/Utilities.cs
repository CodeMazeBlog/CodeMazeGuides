using System.Runtime.InteropServices;

namespace ConvertByteArrayToHexLibrary;

internal class Utilities
{
    public static unsafe string InvariantToLowercase(ReadOnlySpan<char> hexString)
    {
        fixed (char* ptr = &MemoryMarshal.GetReference(hexString))
        {
            return string.Create(hexString.Length, (IntPtr) ptr, (chars, srcPtr) =>
            {
                var sPtr = (uint*) srcPtr;
                fixed (char* dest = &MemoryMarshal.GetReference(chars))
                {
                    var dPtr = (uint*) dest;
                    do
                    {
                        *dPtr++ = ConvertAllAsciiCharsInUInt32ToLowercase(*sPtr++);
                    } while (*sPtr != 0);
                }
            });
        }
    }

    public static unsafe string DangerousInvariantToLowercase(string hexString)
    {
        var span = hexString.AsSpan();
        fixed (char* ptr = &MemoryMarshal.GetReference(span))
        {
            var ptr2 = (uint*) ptr;
            do
            {
                var val = *ptr2;
                *ptr2++ = ConvertAllAsciiCharsInUInt32ToLowercase(val);
            } while (*ptr2 != 0);
        }

        return hexString;
    }

    private static uint ConvertAllAsciiCharsInUInt32ToLowercase(uint value)
    {
        var lowerIndicator = value + 0x0080_0080u - 0x0041_0041u;

        var upperIndicator = value + 0x0080_0080u - 0x005B_005Bu;

        var combinedIndicator = lowerIndicator ^ upperIndicator;

        var mask = (combinedIndicator & 0x0080_0080u) >> 2;

        return value ^ mask;
    }
}