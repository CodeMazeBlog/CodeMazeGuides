using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenerateRandomNumbers;

[TestClass]
public class GenerateRandomNumbersTests
{
    private const int Draws = 10_000;

    [TestMethod]
    public void whenCallingGetPseudoRandomNumber_thenNonNegativeAndBelowIntMaxValue()
    {
        for (var i = 0; i < Draws; i++)
        {
            var num = Program.GetPseudoRandomNumber();
            Assert.IsTrue(num >= 0 && num < int.MaxValue);
        }
    }

    [TestMethod]
    public void whenCallingGetPseudoRandomNumberWithSameSeed_thenSameNumber()
    {
        var first = Program.GetPseudoRandomNumberWithSeed(2);
        var second = Program.GetPseudoRandomNumberWithSeed(2);

        Assert.AreEqual(first, second);
    }

    [TestMethod]
    public void whenCallingGetSecureRandomNumber_thenBetweenZeroAndUpperBoundExclusive()
    {
        var upperBound = 100;
        for (var i = 0; i < Draws; i++)
        {
            var num = Program.GetSecureRandomNumber(upperBound);
            Assert.IsTrue(num >= 0 && num < upperBound);
        }
    }

    [TestMethod]
    public void whenCallingGetPseudoRandomNumberWithinRange_thenUpperBoundIsNeverReturned()
    {
        var returned = new HashSet<int>();
        for (var i = 0; i < Draws; i++)
        {
            returned.Add(Program.GetPseudoRandomNumberWithinRange(1, 7));
        }

        CollectionAssert.AreEquivalent(new[] { 1, 2, 3, 4, 5, 6 }, returned.ToArray());
    }

    [TestMethod]
    public void whenCallingGetPseudoRandomNumberWithEqualBounds_thenLowerBoundIsReturned()
    {
        Assert.AreEqual(5, Program.GetPseudoRandomNumberWithinRange(5, 5));
    }

    [TestMethod]
    public void whenCallingGetPseudoRandomNumberInclusive_thenUpperBoundIsReturned()
    {
        var returned = new HashSet<int>();
        for (var i = 0; i < Draws; i++)
        {
            returned.Add(Program.GetPseudoRandomNumberInclusive(1, 6));
        }

        CollectionAssert.AreEquivalent(new[] { 1, 2, 3, 4, 5, 6 }, returned.ToArray());
    }

    [TestMethod]
    public void whenCallingGetPseudoRandomNumberInclusiveAtIntMaxValue_thenIntMaxValueIsReturned()
    {
        var returned = new HashSet<int>();
        for (var i = 0; i < Draws; i++)
        {
            returned.Add(Program.GetPseudoRandomNumberInclusive(int.MaxValue - 1, int.MaxValue));
        }

        CollectionAssert.AreEquivalent(new[] { int.MaxValue - 1, int.MaxValue }, returned.ToArray());
    }

    [TestMethod]
    public void whenAddingOneToIntMaxValueUpperBound_thenNextThrows()
    {
        var upperBound = int.MaxValue;

        Assert.ThrowsExactly<ArgumentOutOfRangeException>(
            () => Program.GetPseudoRandomNumberWithinRange(int.MaxValue - 1, upperBound + 1));
    }

    [TestMethod]
    public void whenCallingGetPseudoRandomLongWithinRange_thenWithinRange()
    {
        for (var i = 0; i < Draws; i++)
        {
            var num = Program.GetPseudoRandomLongWithinRange(5_000_000_000, 6_000_000_000);
            Assert.IsTrue(num >= 5_000_000_000 && num < 6_000_000_000);
        }
    }

    [TestMethod]
    public void whenCallingGetSecureNumberWithinRange_thenUpperBoundIsNeverReturned()
    {
        var returned = new HashSet<int>();
        for (var i = 0; i < Draws; i++)
        {
            returned.Add(Program.GetSecureNumberWithinRange(-3, 3));
        }

        CollectionAssert.AreEquivalent(new[] { -3, -2, -1, 0, 1, 2 }, returned.ToArray());
    }

    [TestMethod]
    public void whenCallingGetPseudoDouble_thenBetweenZeroAndOneExclusive()
    {
        for (var i = 0; i < Draws; i++)
        {
            var num = Program.GetPseudoDouble();
            Assert.IsTrue(num >= 0.0 && num < 1.0);
        }
    }
}
