namespace CountNumberOfDigitsInANumber
{
    public static class DigitCounter
    {
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

            return 1 + (int)Math.Floor(Math.Log10((double)Math.Abs(number)));
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
            if (number < 1000) return 3;
            if (number < 10000) return 4;
            if (number < 100000) return 5;
            if (number < 1000000) return 6;
            if (number < 10000000) return 7;
            if (number < 100000000) return 8;
            if (number < 1000000000) return 9;

            return 10;
        }
    }
}
