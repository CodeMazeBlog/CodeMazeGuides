using System.Numerics;

namespace ReverseNumberAsInteger
{
    public class ReverseNumbers
    {
        public static int ReverseUsingDigitExtractionAndReconstruction(int num)
        {
            int reversedNumber = 0;

            while (num != 0)
            {
                int remainder = num % 10;

                if (CheckForOverflow(reversedNumber))
                    return 0;

                reversedNumber = reversedNumber * 10 + remainder;
                num /= 10;
            }

            return reversedNumber;
        }

        public static int ReverseUsingModuloAndDivision(int num)
        {
            bool isNegative = false;

            if (num == int.MaxValue || num == int.MinValue)
                return 0;
            else if (num < 0)
            {
                isNegative = true;
                num *= -1;
            }

            int reversedNumber = 0;

            while (num > 0)
            {
                int remainder = num % 10;

                if (CheckForOverflow(reversedNumber))
                    return 0;

                reversedNumber = (reversedNumber * 10) + remainder;

                num /= 10;
            }

            return isNegative == true ? -reversedNumber : reversedNumber;
        }

        public static int ReverseUsingMathPow(int num)
        {
            bool isNegative = false;

            if (num == int.MaxValue || num == int.MinValue)
            {
                return 0;
            }
            
            if (num < 0)
            {
                isNegative = true;
                num *= -1;                 
            }
            
            int length = (int)Math.Floor(Math.Log10(num) + 1);
            int reversedNumber = 0;
            int powerOf10 = (int)Math.Pow(10, length - 1);
  
            for (int i = 1; i <= length; i++)
            {
                
                int remainder = num % 10;

                if ((remainder * (powerOf10 / 10)) >= int.MaxValue / 10)
                    return 0;

                reversedNumber += remainder * powerOf10;

                num /= 10;
                powerOf10 /= 10;
            }

            return isNegative ? -reversedNumber : reversedNumber;
        }

        public static int ReverseBySwappingDigits(int num)
        {
            int rightPtr = 0;
            int reversedNumber = 0;
            bool isNegative = false;

            if (num == int.MaxValue || num == int.MinValue)
            {
                return 0;
            }
            if (num < 0)
            {
                num *= -1;
                isNegative = true;
            }

            int totalNumOfDigits = (int)BigInteger.Log10(BigInteger.Abs(num)) + 1;

            int leftPtr = totalNumOfDigits - 1;

            if (num == 0 || totalNumOfDigits == 1)
                return isNegative ? -num : num;

            var leftPow = (int)Math.Pow(10, leftPtr);
            var rightPow = (int)Math.Pow(10, rightPtr);

            while (leftPtr >= rightPtr)
            {

                int leftDigit = (num / leftPow) % 10;
                int rightDigit = (num / rightPow) % 10;
                if ((rightDigit * (leftPow / 10)) >= int.MaxValue / 10)
                    return 0;

                if (leftPtr != rightPtr)
                {
                    reversedNumber += leftDigit * rightPow;
                    reversedNumber += rightDigit * leftPow;
                }
                else
                {
                    reversedNumber += leftDigit * leftPow;
                }

                leftPtr--;
                rightPtr++;
                leftPow /= 10;
                rightPow *= 10;
            }
         
            return isNegative ? -reversedNumber : reversedNumber;
        }

        public static int ReverseUsingRecursion(int num, int reversedNumber = 0)
        {
            if (num == 0)
            {
                return reversedNumber;
            }

            int remainder = num % 10;

            if (num == int.MaxValue || num == int.MinValue)
                return 0;

            if (CheckForOverflow(reversedNumber))
                return 0;

            reversedNumber = reversedNumber * 10 + remainder;

            return ReverseUsingRecursion(num / 10, reversedNumber);
        }

        public static int ReverseUsingLinq(int num)
        {
            bool isNegative = false;
            if (num == int.MaxValue || num == int.MinValue)
            {
                return 0;
            }
            else if (num < 0)
            {                
                isNegative = true;                
                num *= -1;
            }

            int reversedNumber = num.ToString()
                .Reverse()
                .Select(digit => digit - '0')
                       // .Aggregate(0, (result, digit) => result * 10 + digit - '0');
                       .Aggregate(0, (result, digit) =>
                       {
                           // Check for potential overflow
                           if (CheckForOverflow(result))
                           {
                               return 0; // Handling overflow
                           }
                           return result * 10 + digit;
                       });


            return isNegative ? -reversedNumber : reversedNumber;
        }

        public static int ReverseAsString(int num)
        {
            string numStr = num.ToString();
            char[] charArray = numStr.ToCharArray();
            Array.Reverse(charArray);

            string reversedStr = new string(charArray);

            if (string.IsNullOrEmpty(reversedStr))
            {
                return 0;
            }

            return Int32.Parse(reversedStr);
        }

        private static bool CheckForOverflow(int currentReversedNumber)
        {
            int maxValueDiv10 = int.MaxValue / 10;
            int minValueDiv10 = int.MinValue / 10;
            
            if (currentReversedNumber > 0 && currentReversedNumber > maxValueDiv10)
            {
                return true; // Overflow
            }
            else if (currentReversedNumber < 0 && currentReversedNumber < minValueDiv10)
            {
                return true; // Underflow
            }
                return false;
        }
    }
}