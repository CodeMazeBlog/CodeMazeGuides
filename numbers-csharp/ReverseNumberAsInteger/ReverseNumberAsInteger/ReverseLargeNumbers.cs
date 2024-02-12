using System.Numerics;

namespace ReverseNumberAsInteger
{
    public class ReverseLargeNumbers
    {
        public static BigInteger ReverseUsingDigitExtractionAndReconstruction(BigInteger num)
        {
            BigInteger reversedNumber = 0;

            while (num != 0)
            {
                var remainder = num % 10;
                reversedNumber = reversedNumber * 10 + remainder;
                num /= 10;
            }

            return reversedNumber;
        }        

        public static BigInteger ReverseUsingMathPow(BigInteger num)
        {
            bool isNegative = num < 0;
            num = num < 0 ? BigInteger.Abs(num) : num;
            int length = (int)BigInteger.Log10(num) + 1;
            BigInteger reversedNumber = 0;
            BigInteger powerOf10 = BigInteger.Pow(10, length - 1);

            for (int i = 1; i <= length; i++)
            {
                BigInteger digit = num % 10;
                reversedNumber += digit * powerOf10;
                num /= 10;
                powerOf10 /= 10;
            }

            return isNegative ? -reversedNumber : reversedNumber;
        }

        public static BigInteger ReverseBySwappingDigits(BigInteger num)
        {
            bool isNegative = false;
            if (num < 0)
            {
                isNegative = true;
                num = -num;
            }

            int totalNumOfDigits = (int)BigInteger.Log10(num);
            BigInteger reversedNumber = 0;            

            var leftPow = BigInteger.Pow(10, totalNumOfDigits);
            var rightPow = BigInteger.Pow(10, 0);

           while(leftPow >= rightPow)
            {
                BigInteger leftDigit = (num / leftPow) % 10;
                BigInteger rightDigit = (num / rightPow) % 10;

                if (leftPow != rightPow)
                {
                    reversedNumber += leftDigit * rightPow;
                    reversedNumber += rightDigit * leftPow;
                }
                else
                {
                    reversedNumber += leftDigit * leftPow;
                }

                leftPow /= 10;
                rightPow *= 10;
            }

            return isNegative ? -reversedNumber : reversedNumber;
        }

        public static BigInteger ReverseUsingRecursion(BigInteger num, BigInteger reversedNumber = new BigInteger())
        {
            if (num == 0)
            {
                return reversedNumber;
            }

            BigInteger remainder = num % 10;
            reversedNumber = reversedNumber * 10 + remainder;

            return ReverseUsingRecursion(num / 10, reversedNumber);
        }
        
        public static BigInteger ReverseUsingLinq(BigInteger num)
        {
            bool isNegative = false;
            if (num < 0)
            {
                isNegative = true;
                num *= -1;
            }

            BigInteger reversedNumber = num.ToString()
                .Reverse()
                .Aggregate(BigInteger.Zero, (result, digit) => result * 10 + digit - '0');

            return isNegative ? -reversedNumber : reversedNumber;
        }

        public static BigInteger ReverseAsString(BigInteger num)
        {
            bool isNegative = false;

            if (num < 0)
            {
                isNegative = true;
                num *= -1;
            }

            string numStr = num.ToString();
            char[] charArray = numStr.ToCharArray();
            Array.Reverse(charArray);

            string reversedStr = new(charArray);

            return isNegative ? -BigInteger.Parse(reversedStr) : BigInteger.Parse(reversedStr);
        }
    }
}