namespace ReverseNumberAsInteger
{
    public class ReverseNumbers
    {
        public static int ReverseUsingDigitExtractionAndReconstruction(int num)
        {
            int maxValueDiv10 = int.MaxValue / 10;
            int minValueDiv10 = int.MinValue / 10;

            if (num == int.MaxValue || num == int.MinValue || num == 0)
            {
                return 0;
            }

            int reversedNumber = 0;

            while (num != 0)
            {
                int remainder = num % 10;

                if (reversedNumber > maxValueDiv10 || reversedNumber < minValueDiv10)
                {
                    return 0;
                }

                reversedNumber = reversedNumber * 10 + remainder;
                num /= 10;
            }

            return reversedNumber;
        }

        public static int ReverseUsingRecursion(int num, int reversedNumber = 0)
        {
            int maxValueDiv10 = int.MaxValue / 10;
            int minValueDiv10 = int.MinValue / 10;

            if (num == int.MaxValue || num == int.MinValue || num == 0)
            {
                return reversedNumber;
            }

            if (reversedNumber > maxValueDiv10 || reversedNumber < minValueDiv10)
            {
                return 0;
            }

            int remainder = num % 10;

            reversedNumber = reversedNumber * 10 + remainder;

            return ReverseUsingRecursion(num / 10, reversedNumber);
        }

        public static int ReverseUsingMathPow(int num)
        {
            int maxValueDiv10 = int.MaxValue / 10;

            if (num == int.MaxValue || num == int.MinValue || num == 0)
            {
                return 0;
            }

            bool isNegative = num < 0;
            num = isNegative ? -num : num;

            int length = (int)Math.Floor(Math.Log10(num) + 1);            
            int powerOf10 = (int)Math.Pow(10, length - 1);
            int reversedNumber = 0;

            for (int i = 1; i <= length; i++)
            {                
                int remainder = num % 10;

                if ((remainder * (powerOf10 / 10)) >= maxValueDiv10)
                {
                    return 0;
                }

                reversedNumber += remainder * powerOf10;

                num /= 10;
                powerOf10 /= 10;
            }

            return isNegative ? -reversedNumber : reversedNumber;
        }

        public static int ReverseBySwappingDigits(int num)
        {
            int maxValueDiv10 = int.MaxValue / 10;

            if (num == int.MaxValue || num == int.MinValue || num == 0)
            {
                return 0;
            }

            bool isNegative = num < 0;
            num = isNegative ? -num : num;

            int reversedNumber = 0;

            int totalNumOfDigits = (int)Math.Floor(Math.Log10(num)) + 1;
            int leftPow = (int)Math.Pow(10, totalNumOfDigits - 1);
            int rightPow = 1; 

            while (leftPow >= rightPow)
            {
                int leftDigit = (num / leftPow) % 10;
                int rightDigit = (num / rightPow) % 10;

                if ((rightDigit * (leftPow / 10)) >= maxValueDiv10)
                {
                    return 0;
                }

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

        public static int ReverseAsString(int num)
        {
            if (num == int.MaxValue || num == int.MinValue || num == 0)
            {
                return 0;
            }

            bool isNegative = num < 0;
            char[] numChars = Math.Abs(num).ToString().ToCharArray();
            int length = numChars.Length;
            Span<char> reversedChars = stackalloc char[length];

            for (int i = 0; i < length; i++)
            {
                reversedChars[i] = numChars[length - i - 1];
            }

            if (int.TryParse(reversedChars, out int reversedNumber))
            {
                return isNegative ? -reversedNumber : reversedNumber;
            }
            else
            {
                return 0; 
            }
        }
    }
}