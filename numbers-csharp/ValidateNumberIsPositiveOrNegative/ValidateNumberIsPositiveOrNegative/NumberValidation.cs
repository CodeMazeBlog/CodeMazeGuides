using System.Numerics;
using System.Runtime.InteropServices;

namespace ValidateNumberIsPositiveOrNegative
{
    public static class NumberValidation
    {
        public static int IsPositiveOrNegativeUsingConditionalMethod<T>(T number) where T : ISignedNumber<T>, IComparisonOperators<T, T, bool>
        {
            var result = 0;

            if (number > T.Zero)
            {
                result = 1;
            }
            else if (number < T.Zero)
            {
                result = -1;
            }
            
            return result;
        }
        
        public static unsafe int IsPositiveOrNegativeUsingLeftShiftMethod<T>(T number) where T : unmanaged, IBinaryInteger<T>,ISignedNumber<T>
        {
            var result = 0;

            if (!number.Equals(default(T)))
            {
                int bits = (sizeof(T) * 8) - 1;

                var checkNegative = ((T.CreateChecked(1) << bits) & number) != T.Zero;

                if (checkNegative == true)
                {
                    result = -1;
                }
                else
                {
                    result = 1;
                }
            }
            return result;
        }

        public static unsafe int IsPositiveOrNegativeUsingRightShiftMethod<T>(T number) where T : unmanaged, IBinaryInteger<T>, ISignedNumber<T>
        {
            var result = 0;

            if (!number.Equals(default(T)))
            {
                int bits = (sizeof(T) * 8) - 1;

                var checkNegative = (number >> bits) != T.Zero;

                if (checkNegative == true)
                {
                    result = -1;
                }
                else
                {
                    result = 1;
                }
            }

            return result;
        }

        public static int IsPositiveOrNegativeUsingMathAbsMethod<T>(T number) where T : ISignedNumber<T>
        {
            var result = 0;

            if (number != T.Zero)
            {
                if (T.Abs(number) == number)
                {
                    result = 1;
                }
                else
                {
                    result = -1;
                }
            }
            return result;
        }

        public static int IsPositiveOrNegativeUsingMathSignMethod<T>(T number) where T : INumber<T>
        {
            return T.Sign(number);
        }

        public static int IsPositiveOrNegativeUsingBuiltInMethod<T>(T number) where T : ISignedNumber<T>
        {
            var result = 0;

            if (!number.Equals(default(T)))
            {
                if (T.IsPositive(number))
                {
                    result = 1;
                }
                else if (T.IsNegative(number))
                {
                    result = -1;
                }
            }

            return result;
        }
    }
}
