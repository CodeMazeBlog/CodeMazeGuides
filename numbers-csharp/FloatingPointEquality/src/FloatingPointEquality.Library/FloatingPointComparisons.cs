using System.Numerics;
using System.Runtime.CompilerServices;

namespace FloatingPointEquality.Library;

public static class FloatingPointComparisons
{
    private static readonly double[] HalfNegativePowersOf10 =
    {
        1e0 * 0.5,
        1e-1 * 0.5,
        1e-2 * 0.5,
        1e-3 * 0.5,
        1e-4 * 0.5,
        1e-5 * 0.5,
        1e-6 * 0.5,
        1e-7 * 0.5,
        1e-8 * 0.5,
        1e-9 * 0.5,
        1e-10 * 0.5,
        1e-11 * 0.5,
        1e-12 * 0.5,
        1e-13 * 0.5,
        1e-14 * 0.5,
        1e-15 * 0.5,
        1e-16 * 0.5,
        1e-17 * 0.5
    };

    public static bool EqualityUsingPrecision(double a, double b, int decimalPlaces)
    {
        if (double.IsNaN(a) || double.IsNaN(b)) 
            return false;

        if (double.IsInfinity(a) || double.IsInfinity(b)) 
            return a == b;

        return double.Abs(a - b) < HalfNegativePowersOf10[decimalPlaces];
    }

    public static bool EqualityUsingPrecision(Half a, Half b, int decimalPlaces) =>
        EqualityUsingPrecision((double) a, (double) b, decimalPlaces);

    public static bool EqualityUsingTolerance<T>(T a, T b, T tolerance) where T : IFloatingPointIeee754<T>
    {
        if (T.IsNaN(a) || T.IsNaN(b)) 
            return false;

        if (T.IsInfinity(a) || T.IsInfinity(b)) 
            return a == b;

        return T.Abs(a - b) < tolerance;
    }

    public static bool EqualityUsingMaxUnitsInLastPlace(double a, double b, long maxUnitsInLastPlace)
    {
        if (maxUnitsInLastPlace < 1) 
            throw new ArgumentOutOfRangeException(nameof(maxUnitsInLastPlace));

        if (double.IsNaN(a) || double.IsNaN(b)) return false;

        if (double.IsInfinity(a) || double.IsInfinity(b) || a.IsNegative() != b.IsNegative()) 
            return a == b;

        return long.Abs(BitConverter.DoubleToInt64Bits(a) - BitConverter.DoubleToInt64Bits(b)) <= maxUnitsInLastPlace;
    }

    public static bool EqualityUsingMaxUnitsInLastPlace(float a, float b, int maxUnitsInLastPlace)
    {
        if (maxUnitsInLastPlace < 1) 
            throw new ArgumentOutOfRangeException(nameof(maxUnitsInLastPlace));

        if (float.IsNaN(a) || float.IsNaN(b)) 
            return false;

        if (float.IsInfinity(a) || float.IsInfinity(b) || a.IsNegative() != b.IsNegative()) 
            return a == b;

        return int.Abs(BitConverter.SingleToInt32Bits(a) - BitConverter.SingleToInt32Bits(b)) <= maxUnitsInLastPlace;
    }

    public static bool EqualityUsingMaxUnitsInLastPlace(Half a, Half b, int maxUnitsInLastPlace)
    {
        if (maxUnitsInLastPlace < 1) 
            throw new ArgumentOutOfRangeException(nameof(maxUnitsInLastPlace));

        if (Half.IsNaN(a) || Half.IsNaN(b)) 
            return false;

        if (Half.IsInfinity(a) || Half.IsInfinity(b) || a.IsNegative() != b.IsNegative()) 
            return a == b;

        return int.Abs(BitConverter.HalfToInt16Bits(a) - BitConverter.HalfToInt16Bits(b)) <= maxUnitsInLastPlace;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsNegative<T>(this T value) where T : IFloatingPointIeee754<T>
        => T.IsNegative(value);
}