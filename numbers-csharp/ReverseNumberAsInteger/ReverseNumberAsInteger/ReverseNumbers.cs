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
                var remainder = num % 10;

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

            var remainder = num % 10;

            reversedNumber = reversedNumber * 10 + remainder;

            return ReverseUsingRecursion(num / 10, reversedNumber);
        }

        public static int ReverseUsingMathPow(int num)
        {
            int maxValueDiv10 = int.MaxValue / 10;
            var isNegative = num < 0;
            num = isNegative ? -num : num;

            if (num == int.MaxValue || num == int.MinValue || num == 0)
            {
                return 0;
            }

            int length = (int)Math.Floor(Math.Log10(num) + 1);
            int reversedNumber = 0;
            int[] powersOf10 = new int[10];
            powersOf10[0] = 1;

            for (int i = 1; i < 10; i++)
            {
                powersOf10[i] = powersOf10[i - 1] * 10;
            }            

            for (int i = length - 1; i >= 0; i--)
            {
                var remainder = num % 10;

                if ((remainder * powersOf10[i] / 10) >= maxValueDiv10)
                {
                    return 0;
                }

                reversedNumber += remainder * powersOf10[i];

                num /= 10;
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

            var isNegative = num < 0;
            num = isNegative ? -num : num;
            int reversedNumber = 0;
            int totalNumOfDigits = (int)Math.Floor(Math.Log10(num)) + 1;
            int[] powersOf10 = new int[10];
            powersOf10[0] = 1;

            for (int i = 1; i < 10; i++)
            {
                powersOf10[i] = powersOf10[i - 1] * 10;
            }

            var leftPowIndex = totalNumOfDigits - 1;
            var rightPowIndex = 0;

            while (leftPowIndex >= rightPowIndex)
            {
                var leftDigit = (num / powersOf10[leftPowIndex]) % 10;
                var rightDigit = (num / powersOf10[rightPowIndex]) % 10;

                if ((rightDigit * (powersOf10[leftPowIndex] / 10)) >= maxValueDiv10)
                {
                    return 0;
                }

                if (leftPowIndex != rightPowIndex)
                {
                    reversedNumber += leftDigit * powersOf10[rightPowIndex];
                    reversedNumber += rightDigit * powersOf10[leftPowIndex];
                }
                else
                {
                    reversedNumber += leftDigit * powersOf10[leftPowIndex];
                }

                leftPowIndex--;
                rightPowIndex++;
            }

            return isNegative ? -reversedNumber : reversedNumber;
        }

        public static int ReverseAsString(int num)
        {
            if (num == int.MaxValue || num == int.MinValue || num == 0)
            {
                return 0;
            }

            var isNegative = num < 0;
            ReadOnlySpan<char> numChars = Math.Abs(num).ToString().AsSpan();
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