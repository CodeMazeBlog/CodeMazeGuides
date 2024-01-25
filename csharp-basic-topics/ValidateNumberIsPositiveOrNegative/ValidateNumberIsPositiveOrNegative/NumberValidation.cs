using System.Numerics;

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

        public static int IsPositiveOrNegativeUsingLeftShiftMethod<T>(T number) where T : IBinaryInteger<T>, IBitwiseOperators<T, T, T>
        {
            var result = 0;

            if (!number.Equals(default(T)))
            {
                var isNumberNegative = (T.RotateLeft(number, 31) & number) != T.Zero;

                if (isNumberNegative == true)
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

        public static int IsPositiveOrNegativeUsingRightShiftMethod<T>(T number) where T : IBinaryInteger<T>, IBitwiseOperators<T, T, T>
        {
            var result = 0;

            if (!number.Equals(default(T)))
            {
                var isNumberNegative = (T.RotateRight(number, 31) & number) != T.Zero;

                if (isNumberNegative == true)
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

        public static int IsPositiveOrNegativeUsingMathAbsMethod(int number)
        {
            var result = 0;

            if (number != 0)
            {
                if (Math.Abs(number) == number)
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

        public static int IsPositiveOrNegativeUsingMathSignMethod(int number)
        {
            return Math.Sign(number);
        }

        public static int IsPositiveOrNegativeUsingBuiltInMethod<T>(T number) where T : ISignedNumber<T>, IComparisonOperators<T, T, bool>
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
