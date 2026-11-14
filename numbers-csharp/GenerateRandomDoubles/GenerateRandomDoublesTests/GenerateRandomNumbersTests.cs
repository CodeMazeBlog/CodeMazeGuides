using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenerateRandomNumbers;

[TestClass]
public class GenerateRandomNumbersTests
{
    private const int Draws = 1000;

    [TestMethod]
    public void WhenCallingGetPseudoDouble_ThenBetweenZeroAndOne()
    {
        for (var i = 0; i < Draws; i++)
        {
            var num = Program.GetPseudoDouble();
            Assert.IsTrue(num >= 0.0 && num < 1.0, $"{num} is outside [0, 1)");
        }
    }

    [TestMethod]
    public void WhenCallingGetPseudoDoubleWithinRange_ThenWithinRange()
    {
        double lowerBound = 4;
        double upperBound = 400;
        for (var i = 0; i < Draws; i++)
        {
            var num = Program.GetPseudoDoubleWithinRange(lowerBound, upperBound);
            Assert.IsTrue(num >= lowerBound && num < upperBound, $"{num} is outside the range");
        }
    }

    [TestMethod]
    public void WhenCallingGetSecureDouble_ThenBetweenZeroAndOne()
    {
        for (var i = 0; i < Draws; i++)
        {
            var num = Program.GetSecureDouble();
            Assert.IsTrue(num >= 0.0 && num < 1.0, $"{num} is outside [0, 1)");
        }
    }

    [TestMethod]
    public void WhenCallingGetSecureDouble_ThenValuesSpreadAcrossTheInterval()
    {
        var aboveHalf = 0;
        for (var i = 0; i < Draws; i++)
        {
            if (Program.GetSecureDouble() >= 0.5) aboveHalf++;
        }

        Assert.IsTrue(aboveHalf > 0, "No secure double landed in the upper half");
        Assert.IsTrue(aboveHalf < Draws, "Every secure double landed in the upper half");
    }

    [TestMethod]
    public void WhenCallingGetSecureDoubleWithinRange_ThenWithinRange()
    {
        double lowerBound = 5;
        double upperBound = 500;
        for (var i = 0; i < Draws; i++)
        {
            var num = Program.GetSecureDoubleWithinRange(lowerBound, upperBound);
            Assert.IsTrue(num >= lowerBound && num < upperBound, $"{num} is outside the range");
        }
    }

    [TestMethod]
    public void WhenScalingTheLargestNextDoubleToOneAndTwo_ThenResultRoundsToUpperBound()
    {
        var largest = Math.BitDecrement(1.0);

        Assert.AreEqual(2.0, largest * (2.0 - 1.0) + 1.0);
    }

    [TestMethod]
    public void WhenCallingGetPseudoDoubleBelowUpperBound_ThenBelowUpperBound()
    {
        for (var i = 0; i < Draws; i++)
        {
            var num = Program.GetPseudoDoubleBelowUpperBound(1.0, 2.0);
            Assert.IsTrue(num >= 1.0 && num < 2.0, $"{num} is outside [1, 2)");
        }
    }

    [TestMethod]
    public void WhenTheRangeIsWiderThanDoubleMaxValue_ThenOnlyTheWideRangeFormulaStaysFinite()
    {
        var plain = Program.GetPseudoDoubleWithinRange(double.MinValue, double.MaxValue);
        var wide = Program.GetPseudoDoubleWithinWideRange(double.MinValue, double.MaxValue);

        Assert.IsFalse(double.IsFinite(plain));
        Assert.IsTrue(double.IsFinite(wide));
    }
}
