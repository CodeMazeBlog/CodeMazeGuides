namespace RoundDownToNearestInteger
{
    public class RoundingMethods
    {
        public static int[] RoundDownUsingMathFloor(double[] testCases)
        {
            var results = new int[testCases.Length];

            for (var cnt = 0; cnt < testCases.Length; cnt++)
            {
                results[cnt] = (int)Math.Floor(testCases[cnt]);
            }

            return results;
        }

        public static int[] RoundDownUsingMathTruncate(double[] testCases)
        {
            var results = new int[testCases.Length];

            for (var cnt = 0; cnt < testCases.Length; cnt++)
            {
                results[cnt] = (int)Math.Truncate(testCases[cnt]);
            }

            return results;
        }

        public static int[] RoundDownUsingMathRoundWithToEvenMode(double[] testCases)
        {
            var results = new int[testCases.Length];

            for (var cnt = 0; cnt < testCases.Length; cnt++)
            {
                results[cnt] = (int)Math.Round(testCases[cnt], MidpointRounding.ToEven);
            }

            return results;
        }

        public static int[] RoundDownUsingMathRoundWithAwayFromZeroMode(double[] testCases)
        {
            var results = new int[testCases.Length];

            for (var cnt = 0; cnt < testCases.Length; cnt++)
            {
                results[cnt] = (int)Math.Round(testCases[cnt], MidpointRounding.AwayFromZero);
            }

            return results;
        }

        public static int[] RoundDownUsingMathRoundWithToZeroMode(double[] testCases)
        {
            var results = new int[testCases.Length];

            for (var cnt = 0; cnt < testCases.Length; cnt++)
            {
                results[cnt] = (int)Math.Round(testCases[cnt], MidpointRounding.ToZero);
            }

            return results;
        }

        public static int[] RoundDownUsingMathRoundWithToNegativeInfinityMode(double[] testCases)
        {
            var results = new int[testCases.Length];

            for (var cnt = 0; cnt < testCases.Length; cnt++)
            {
                results[cnt] = (int)Math.Round(testCases[cnt], MidpointRounding.ToNegativeInfinity);
            }

            return results;
        }

        public static int[] RoundDownUsingMathRoundWithToPositiveInfinityMode(double[] testCases)
        {
            var results = new int[testCases.Length];

            for (var cnt = 0; cnt < testCases.Length; cnt++)
            {
                results[cnt] = (int)Math.Round(testCases[cnt], MidpointRounding.ToPositiveInfinity);
            }

            return results;
        }

        public static int[] RoundDownUsingConvertToInt32(double[] testCases)
        {
            var results = new int[testCases.Length];

            for (var cnt = 0; cnt < testCases.Length; cnt++)
            {
                results[cnt] = Convert.ToInt32(testCases[cnt]);
            }

            return results;
        }

        public static int[] RoundDownUsingCasting(double[] testCases)
        {
            var results = new int[testCases.Length];

            for (var cnt = 0; cnt < testCases.Length; cnt++)
            {
                results[cnt] = (int)testCases[cnt];
            }

            return results;
        }

        public static int[] RoundDownUsingSubtractionWithModulo(double[] testCases)
        {
            var results = new int[testCases.Length];

            for (var cnt = 0; cnt < testCases.Length; cnt++)
            {
                results[cnt] = (int)(testCases[cnt] - (testCases[cnt] % 1));
            }

            return results;
        }
    }
}