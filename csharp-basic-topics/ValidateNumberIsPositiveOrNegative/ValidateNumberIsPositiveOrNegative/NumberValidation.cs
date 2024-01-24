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
        //TODO: This works fine when called from main method but failing when called from test case.
        public static bool IsNegativeShift<T>(T val) where T : IBinaryInteger<T>, IBitwiseOperators<T, T, T>
        {
            return (T.RotateLeft(val, 31) & val) != T.Zero;
        }

        public static int IsPositiveOrNegativeUsingLeftShiftMethod(int number) 
        {
            var result = 0;

            if (number != 0)
            {
                // Using left shift operator to check the sign bit
                if ((number & (1 << 31)) == 0)
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

        public static int IsPositiveOrNegativeUsingRightShiftMethod(int number)
        {
            var result = 0;

            if(number != 0) 
            {
                // Using right shift operator to check the sign bit
                if ((number >> 31) == 0)
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
