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
            
            return result;
        }

        public static int IsPositiveOrNegativeUsingLeftShiftMethod(int number)
        {
            var result = 0;

            // Using left shift operator to check the sign bit
            if(number != 0) 
            { 
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

            // Using right shift operator to check the sign bit
            if(number != 0) 
            { 
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
            var result = 0;

            if (number != 0)
            {
                result = Math.Sign(number);
            }
            
            return result;
        }

        public static int IsPositiveOrNegative(int number)
        {
            var result = 0;

            if (number != 0)
            {
                if (Int32.IsPositive(number))
                {
                    result = 1;
                }
                else if (Int32.IsNegative(number))
                {
                    result = -1;
                }
            }
            return result;
        }
    }
}
