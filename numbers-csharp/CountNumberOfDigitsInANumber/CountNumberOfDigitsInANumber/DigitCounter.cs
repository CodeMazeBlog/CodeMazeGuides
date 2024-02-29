namespace CountNumberOfDigitsInANumber
{
    public static class DigitCounter
    {
        private static readonly int[] _guessDigits = [9, 9, 9, 8, 8, 8, 7, 7, 7, 6, 6, 6, 6, 5, 5, 5, 4, 4, 4, 3, 3, 3, 3, 2, 2, 2, 1, 1, 1, 0, 0, 0, 0];
        private static readonly int[] _powersOf10 = [1, 10, 100, 1_000, 10_000, 100_000, 1_000_000, 10_000_000, 100_000_000, 1_000_000_000];

        public static int GetBitManipCount(int number)
        {
            if (number == 0)
            {
                return 1;
            }

            number = Math.Abs(number);
            var leading = BitOperations.LeadingZeroCount((uint)number);
            var digits = _guessDigits[leading];
            if (number >= _powersOf10[digits])
            {
                ++digits;
            }

            return digits;
        }

        public static int GetIterativeCount(int number)
        {
            if (number == 0)
            {
                return 1;
            }

            int count = 0;
            while (number != 0)
            {
                number /= 10;
                count++;
            }

            return count;
        }

        public static int GetRecursiveCount(int number)
        {
            if (Math.Abs(number) < 10) 
            {
                return 1;
            }

            return 1 + GetRecursiveCount(number / 10);
        }

        public static int GetLog10Count(int number)
        {
            if (number == 0)
            {
                return 1;
            }

            return 1 + (int)Math.Floor(Math.Log10(Math.Abs(number)));
        }

        public static int GetStringLengthCount(int number)
        {
            return Math.Abs(number).ToString().Length;
        }

        public static int GetIfChainCount(int number)
        {
            number = Math.Abs(number);
            if (number < 10) return 1;
            if (number < 100) return 2;
            if (number < 1_000) return 3;
            if (number < 10_000) return 4;
            if (number < 100_000) return 5;
            if (number < 1_000_000) return 6;
            if (number < 10_000_000) return 7;
            if (number < 100_000_000) return 8;
            if (number < 1_000_000_000) return 9;

            return 10;
        }
    }
}
