using System.Numerics;

namespace ValidateNumberIsPositiveOrNegative;

public static class NumberValidation
{
    public static int IsPositiveOrNegativeUsingConditionalMethod<T>(T number) where T : ISignedNumber<T>, IComparisonOperators<T, T, bool>
    {
        if (number == T.Zero)
            return 0;

        return number > T.Zero ? 1 : -1;
    }

    public static unsafe int IsPositiveOrNegativeUsingLeftShiftMethod<T>(T number) where T : unmanaged, IBinaryInteger<T>,ISignedNumber<T>
    {
        if (number == T.Zero)
            return 0;

        int bits = sizeof(T) * 8 - 1;

        return ((T.One << bits) & number) == T.Zero ? 1 : -1;
    }

    public static unsafe int IsPositiveOrNegativeUsingRightShiftMethod<T>(T number) where T : unmanaged, IBinaryInteger<T>, ISignedNumber<T>
    {
        if (number == T.Zero)
            return 0;

        int bits = sizeof(T) * 8 - 1;

        return number >> bits == T.Zero ? 1 : -1;
    }

    public static int IsPositiveOrNegativeUsingMathAbsMethod<T>(T number) where T : ISignedNumber<T>
    {
        if (number == T.Zero)
            return 0;

        return T.Abs(number) == number ? 1 : -1;
    }

    public static int IsPositiveOrNegativeUsingMathSignMethod<T>(T number) where T : INumber<T>
    {
        return T.Sign(number);
    }

    public static int IsPositiveOrNegativeUsingBuiltInMethod<T>(T number) where T : ISignedNumber<T>
    {
        if (number == T.Zero)
            return 0;

        return T.IsPositive(number) ? 1 : -1;
    }
}