using RoundDownToNearestInteger;

namespace Tests;

[TestClass]
public class RoundDownToNearestIntegerTests
{
    private readonly double[] testCases = [2.5, 1.75, 1.5, 1.25, -1.25, -1.5, -1.75, -2.5];

    [TestMethod]
    public void WhenRoundingUsingMathFloor_ThenCorrectResult()
    {
        var result = RoundingMethods.RoundDownUsingMathFloor(testCases);
        int[] expected = [2, 1, 1, 1, -2, -2, -2, -3];

        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void WhenRoundingUsingMathTruncate_ThenCorrectResult()
    {
        var result = RoundingMethods.RoundDownUsingMathTruncate(testCases);
        int[] expected = [2, 1, 1, 1, -1, -1, -1, -2];

        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void WhenRoundingUsingMathRoundWithToEvenMode_ThenCorrectResult()
    {
        var result = RoundingMethods.RoundDownUsingMathRoundWithToEvenMode(testCases);
        int[] expected = [2, 2, 2, 1, -1, -2, -2, -2];

        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void WhenRoundingUsingMathRoundWithAwayFromZeroMode_ThenCorrectResult()
    {
        var result = RoundingMethods.RoundDownUsingMathRoundWithAwayFromZeroMode(testCases);
        int[] expected = [3, 2, 2, 1, -1, -2, -2, -3];

        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void WhenRoundingUsingMathRoundWithToZeroMode_ThenCorrectResult()
    {
        var result = RoundingMethods.RoundDownUsingMathRoundWithToZeroMode(testCases);
        int[] expected = [2, 1, 1, 1, -1, -1, -1, -2];

        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void WhenRoundingUsingMathRoundWithToNegativeInfinityMode_ThenCorrectResult()
    {
        var result = RoundingMethods.RoundDownUsingMathRoundWithToNegativeInfinityMode(testCases);
        int[] expected = [2, 1, 1, 1, -2, -2, -2, -3];

        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void WhenRoundingUsingMathRoundWithToPositiveInfinityMode_ThenCorrectResult()
    {
        var result = RoundingMethods.RoundDownUsingMathRoundWithToPositiveInfinityMode(testCases);
        int[] expected = [3, 2, 2, 2, -1, -1, -1, -2];

        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void WhenRoundingUsingConvertToInt32_ThenCorrectResult()
    {
        var result = RoundingMethods.RoundDownUsingConvertToInt32(testCases);
        int[] expected = [2, 2, 2, 1, -1, -2, -2, -2];

        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void WhenRoundingUsingCasting_ThenCorrectResult()
    {
        var result = RoundingMethods.RoundDownUsingCasting(testCases);
        int[] expected = [2, 1, 1, 1, -1, -1, -1, -2];

        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void WhenRoundingUsingSubtractionWithModulo_ThenCorrectResult()
    {
        var result = RoundingMethods.RoundDownUsingSubtractionWithModulo(testCases);
        int[] expected = [2, 1, 1, 1, -1, -1, -1, -2];

        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void WhenRoundingUpUsingMathCeiling_ThenCorrectResult()
    {
        var result = RoundingMethods.RoundUpUsingMathCeiling(testCases);
        int[] expected = [3, 2, 2, 2, -1, -1, -1, -2];

        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    [DataRow(7, 2, 3)]
    [DataRow(-7, 2, -4)]
    [DataRow(7, -2, -4)]
    [DataRow(-7, -2, 3)]
    [DataRow(-6, 2, -3)]
    public void WhenDividingAndRoundingDown_ThenResultIsFloorOfQuotient(int dividend, int divisor, int expected)
    {
        Assert.AreEqual(expected, RoundingMethods.DivideAndRoundDown(dividend, divisor));
    }

    [TestMethod]
    public void WhenIntegerDividingNegativeNumber_ThenResultIsTruncatedTowardZero()
    {
        var dividend = -7;
        var divisor = 2;

        Assert.AreEqual(-3, dividend / divisor);
    }

    [TestMethod]
    public void WhenCastingOutOfRangeValue_ThenResultSaturates()
    {
        var tooBig = 1e10;
        var notANumber = double.NaN;

        Assert.AreEqual(int.MaxValue, (int)tooBig);
        Assert.AreEqual(int.MinValue, (int)-tooBig);
        Assert.AreEqual(0, (int)notANumber);
    }

    [TestMethod]
    public void WhenConvertingOutOfRangeValue_ThenOverflowExceptionIsThrown()
    {
        Assert.ThrowsExactly<OverflowException>(() => Convert.ToInt32(1e10));
    }
}
