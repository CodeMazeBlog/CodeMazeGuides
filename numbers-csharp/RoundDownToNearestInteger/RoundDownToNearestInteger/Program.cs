namespace RoundDownToNearestInteger
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var testCases = new double[] { 2.5, 1.75, 1.5, 1.25, -1.25, -1.5, -1.75, -2.5 };
            var desiredResults = new int[] { 2, 1, 1, 1, -2, -2, -2, -3 };

            OutputRoundingResults.RoundDownUsingMathFloor(testCases, desiredResults);

            OutputRoundingResults.RoundDownUsingMathTruncate(testCases, desiredResults);

            OutputRoundingResults.RoundDownUsingMathRoundWithToEvenMode(testCases, desiredResults);

            OutputRoundingResults.RoundDownUsingMathRoundWithAwayFromZeroMode(testCases, desiredResults);

            OutputRoundingResults.RoundDownUsingMathRoundWithToZeroMode(testCases, desiredResults);

            OutputRoundingResults.RoundDownUsingMathRoundWithToNegativeInfinityMode(testCases, desiredResults);

            OutputRoundingResults.RoundDownUsingMathRoundWithToPositiveInfinityMode(testCases, desiredResults);

            OutputRoundingResults.RoundDownUsingConvertToInt32(testCases, desiredResults);

            OutputRoundingResults.RoundDownUsingCasting(testCases, desiredResults);

            OutputRoundingResults.RoundDownUsingSubtractionWithModulo(testCases, desiredResults);
        }
    }
}