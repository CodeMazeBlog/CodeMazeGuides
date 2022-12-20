using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BoxingAndUnboxingInCSharp
{
    public static class Conversion
    {
        public static object BoxToInt(int value) => value;
        public static object BoxToNint(nint value) => value;
        public static object BoxToNuint(nuint value) => value;
        public static object BoxToUint(uint value) => value;
        public static object BoxToShort(short value) => value;
        public static object BoxToUshort(ushort value) => value;
        public static object BoxToLong(long value) => value;
        public static object BoxToUlong(ulong value) => value;
        public static object BoxToDouble(double value) => value;
        public static object BoxToDecimal(decimal value) => value;
        public static object BoxToFloat(float value) => value;
        public static object BoxToByte(byte value) => value;
        public static object BoxToSbyte(sbyte value) => value;
        public static object BoxToChar(char value) => value;


        public static int UnboxToInt(object o) => (int)o;
        public static nint UnboxToNint(object o) => (nint)o;
        public static nuint UnboxToNuint(object o) => (nuint)o;
        public static uint UnboxToUint(object o) => (uint)o;
        public static short UnboxToShort(object o) => (short)o;
        public static ushort UnboxToUshort(object o) => (ushort)o;
        public static long UnboxToLong(object o) => (long)o;
        public static ulong UnboxToUlong(object o) => (ulong)o;
        public static double UnboxToDouble(object o) => (double)o;
        public static decimal UnboxToDecimal(object o) => (decimal)o;
        public static float UnboxToFloat(object o) => (float)o;
        public static byte UnboxToByte(object o) => (byte)o;
        public static sbyte UnboxToSbyte(object o) => (sbyte)o;
        public static char UnboxToChar(object o) => (char)o;
    }
}
