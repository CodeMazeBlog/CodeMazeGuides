using System.Numerics;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;


namespace CheckIfNumberIsPowerOf2;

static public class PowerOf2Verifier
{
    static public bool CheckWithLog(int n) 
    {
        var log = Math.Log2(n);
        return log == Math.Floor(log) && n > 0;
    }

    static public bool CheckWithLog(ulong n) 
    {
        var log = Math.Log2(n);
        return log == Math.Floor(log) && n > 0;
    }

    static public bool CheckWithBitMaskV1(int n) => (n & (-n)) == n && n > 0;

    // ERROR: Operator '-' cannot be applied to operand of type 'ulong' 
    // static public bool CheckWithBitMaskV1(ulong n) => (n & (-n)) == n && n != 0;

    static public bool CheckWithBitMaskV2(int n) => (n & (~n + 1)) == n && n > 0;

    static public bool CheckWithBitMaskV3(int n) => (n & (n - 1)) == 0 && n > 0;
}
