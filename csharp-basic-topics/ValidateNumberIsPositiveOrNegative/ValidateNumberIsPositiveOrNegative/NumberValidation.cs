using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidateNumberIsPositiveOrNegative
{
    public static class NumberValidation
    {
        public static int IsPositiveOrNegativeUsingConditionalMethod(int number)
        {
            var result = 0;

            if (number > 0)
            {
                result = 1;
            }
            else if (number < 0)
            {
                result = - 1;
            }
            else
            {
                result = 0;
            }
            return result;
        }
        public static int IsPositiveOrNegativeUsingLeftShiftMethod(int number)
        {
            var result = 0;
            // Using left shift operator to check the sign bit
            if ((number & (1 << 31)) == 0)
            {
                result = 1;
            }
            else
            {
                result = -1;
            }
            return result;
        }
        public static int IsPositiveOrNegativeUsingRightShiftMethod(int number)
        {
            var result = 0;
            // Using right shift operator to check the sign bit
            if ((number >> 31) == 0)
            {
                result = 1;
            }
            else
            {
                result = -1;
            }
            return result;
        }
        public static int IsPositiveOrNegativeUsingMathAbsMethod(int number)
        {
            var result = 0;
            int absoluteValue = Math.Abs(number);

            if (absoluteValue == number)
            {
                result = 1;
            }
            else
            {
                result = -1;
            }
            return result;
        }
        public static int IsPositiveOrNegativeUsingMathSignMethod(int number)
        {
            var result = 0;
            int sign = Math.Sign(number);

            if (sign == 1)
            {
                result = 1;
            }
            else if (sign == -1)
            {
                result = -1;
            }
            else
            {
                result = 0;
            }
            return result;
        }
        public static int IsPositiveOrNegative(int number)
        {
            var result = 0;
            bool isPositive = Int32.IsPositive(number);
            bool isNegative = Int32.IsNegative(number);

            if (isPositive)
            {
                result = 1;
            }
            if (isNegative)
            {
                result = -1;
            }
            return result;
        }
    }
}
