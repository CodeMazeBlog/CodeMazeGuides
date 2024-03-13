namespace CountNumberOfDigitsInANumber
{
    public static class DigitCounter
    {
        private static readonly int[] GuessDigits = [9, 9, 9, 8, 8, 8, 7, 7, 7, 6, 6, 6, 6, 5, 5, 5, 4, 4, 4, 3, 3, 3, 3, 2, 2, 2, 1, 1, 1, 0, 0, 0, 0];
        private static readonly int[] PowersOf10 = [1, 10, 100, 1_000, 10_000, 100_000, 1_000_000, 10_000_000, 100_000_000, 1_000_000_000];
        
        public static int GetBitManipulationCount(int number)
        {
            if (number == 0)
            {
                return 1;
            }

            number = Math.Abs(number);
            var leading = BitOperations.LeadingZeroCount((uint)number);
            var digits = GuessDigits[leading];
            if (number >= PowersOf10[digits])
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

        /// <summary>
        /// Algorithm from https://source.dot.net/#System.Private.CoreLib/src/libraries/System.Private.CoreLib/src/System/Buffers/Text/FormattingHelpers.CountDigits.cs,7170ea53e8923fad
        /// based upon this article: https://lemire.me/blog/2021/06/03/computing-the-number-of-digits-of-an-integer-even-faster
        /// </summary>
        public static int GetFastCount(int number)
        {
            uint value = (uint)Math.Abs(number);

            ReadOnlySpan<long> table =
            [
                4_294_967_296,
                8_589_934_582,
                8_589_934_582,
                8_589_934_582,
                12_884_901_788,
                12_884_901_788,
                12_884_901_788,
                17_179_868_184,
                17_179_868_184,
                17_179_868_184,
                21_474_826_480,
                21_474_826_480,
                21_474_826_480,
                21_474_826_480,
                25_769_703_776,
                25_769_703_776,
                25_769_703_776,
                30_063_771_072,
                30_063_771_072,
                30_063_771_072,
                34_349_738_368,
                34_349_738_368,
                34_349_738_368,
                34_349_738_368,
                38_554_705_664,
                38_554_705_664,
                38_554_705_664,
                41_949_672_960,
                41_949_672_960,
                41_949_672_960,
                42_949_672_960,
                42_949_672_960,
            ];

            long tableValue = Unsafe.Add(ref MemoryMarshal.GetReference(table), uint.Log2(value));

            return (int)((value + tableValue) >> 32);
        }
    }
}
