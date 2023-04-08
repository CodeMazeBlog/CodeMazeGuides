namespace RoundDownToNearestInteger
{
    internal static class OutputRoundingResults
    {
        private static void WriteResultsToConsole(double[] testCases, int[] results, int[] desiredResults)
        {
            for (var cnt = 0; cnt < testCases.Length; cnt++)
            {
                Console.WriteLine($"Rounding {testCases[cnt]} results in {results[cnt]} (desired result: {desiredResults[cnt]})");
            }

            Console.WriteLine();
        }

        public static void RoundDownUsingMathFloor(double[] testCases, int[] desiredResults)
        {
            Console.WriteLine($"Round down using Math.Floor():");
            var results = RoundingMethods.RoundDownUsingMathFloor(testCases);
            WriteResultsToConsole(testCases, results, desiredResults);
        }

        public static void RoundDownUsingMathTruncate(double[] testCases, int[] desiredResults)
        {
            Console.WriteLine($"Round down using Math.Truncate():");
            var results = RoundingMethods.RoundDownUsingMathTruncate(testCases);
            WriteResultsToConsole(testCases, results, desiredResults);
        }

        public static void RoundDownUsingMathRoundWithToEvenMode(double[] testCases, int[] desiredResults)
        {
            Console.WriteLine($"Round down using Math.Round() with ToEven mode:");
            var results = RoundingMethods.RoundDownUsingMathRoundWithToEvenMode(testCases);
            WriteResultsToConsole(testCases, results, desiredResults);
        }

        public static void RoundDownUsingMathRoundWithAwayFromZeroMode(double[] testCases, int[] desiredResults)
        {
            Console.WriteLine($"Round down using Math.Round() with AwayFromZero mode:");
            var results = RoundingMethods.RoundDownUsingMathRoundWithAwayFromZeroMode(testCases);
            WriteResultsToConsole(testCases, results, desiredResults);
        }

        public static void RoundDownUsingMathRoundWithToZeroMode(double[] testCases, int[] desiredResults)
        {
            Console.WriteLine($"Round down using Math.Round() with ToZero mode:");
            var results = RoundingMethods.RoundDownUsingMathRoundWithToZeroMode(testCases);
            WriteResultsToConsole(testCases, results, desiredResults);
        }

        public static void RoundDownUsingMathRoundWithToNegativeInfinityMode(double[] testCases, int[] desiredResults)
        {
            Console.WriteLine($"Round down using Math.Round() with ToNegativeInfinity mode:");
            var results = RoundingMethods.RoundDownUsingMathRoundWithToNegativeInfinityMode(testCases);
            WriteResultsToConsole(testCases, results, desiredResults);
        }

        public static void RoundDownUsingMathRoundWithToPositiveInfinityMode(double[] testCases, int[] desiredResults)
        {
            Console.WriteLine($"Round down using Math.Round() with ToPositiveInfinity mode:");
            var results = RoundingMethods.RoundDownUsingMathRoundWithToPositiveInfinityMode(testCases);
            WriteResultsToConsole(testCases, results, desiredResults);
        }

        public static void RoundDownUsingConvertToInt32(double[] testCases, int[] desiredResults)
        {
            Console.WriteLine($"Round down using Convert.ToInt32():");
            var results = RoundingMethods.RoundDownUsingConvertToInt32(testCases);
            WriteResultsToConsole(testCases, results, desiredResults);
        }

        public static void RoundDownUsingCasting(double[] testCases, int[] desiredResults)
        {
            Console.WriteLine($"Round down using casting:");
            var results = RoundingMethods.RoundDownUsingCasting(testCases);
            WriteResultsToConsole(testCases, results, desiredResults);
        }

        public static void RoundDownUsingSubtractionWithModulo(double[] testCases, int[] desiredResults)
        {
            Console.WriteLine($"Round down using subtraction with modulo:");
            var results = RoundingMethods.RoundDownUsingSubtractionWithModulo(testCases);
            WriteResultsToConsole(testCases, results, desiredResults);
        }
    }
}