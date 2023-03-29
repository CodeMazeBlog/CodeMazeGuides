namespace RoundDownToNearestInteger
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var testCases = new double[] { 2.5, 1.75, 1.5, 1.25, -1.75, -1.5, -1.25, -2.5 };
            //-----------------------////{ 2,   1,    1,   1,    -2,    -2,   -2,    -3 }

            OutputRoundingResults.RoundDownUsingMathFloor(testCases);

            OutputRoundingResults.RoundDownUsingMathTruncate(testCases);

            OutputRoundingResults.RoundDownUsingMathRoundWithToEvenMode(testCases);

            OutputRoundingResults.RoundDownUsingMathRoundWithAwayFromZeroMode(testCases);

            OutputRoundingResults.RoundDownUsingMathRoundWithToZeroMode(testCases);

            OutputRoundingResults.RoundDownUsingMathRoundWithToNegativeInfinityMode(testCases);

            OutputRoundingResults.RoundDownUsingMathRoundWithToPositiveInfinityMode(testCases);

            OutputRoundingResults.RoundDownUsingConvertToInt32(testCases);

            OutputRoundingResults.RoundDownUsingCasting(testCases);

            OutputRoundingResults.RoundDownUsingSubtractionWithModulo(testCases);
        }
    }
}