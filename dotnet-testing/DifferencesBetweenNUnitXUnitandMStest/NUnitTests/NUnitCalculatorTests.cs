using DifferencesBetweenNUnitXUnitandMStest;

namespace NUnitTests;

[TestFixture]
public class NUnitCalculatorTests
{
    [Test]
    [Category("Sum")]
    [Property("NegativeNumbers", "false")]
    public void GivenTwoIntegers_WhenAdded_ThenShouldReturnSum()
    {
        var result = Calculator.Add(3, 7);

        Assert.That(result, Is.EqualTo(10));
    }

    [Test]
    [Category("Sum")]
    [Property("NegativeNumbers", "true")]
    public void GivenTwoIntegers_WhenAdded_ThenShouldReturnCorrectNegativeSum()
    {
        var result = Calculator.Add(-3, 7);

        Assert.That(result, Is.EqualTo(4));
    }

    [TestCase(8, 9, 17)]
    [TestCase(0, 0, 0)]
    [TestCase(-2, 56, 54)]
    public void GivenTwoIntegersInTestCase_WhenAdded_ThenShouldReturnSum(int a, int b, int expected)
    {
        var result = Calculator.Add(a, b);

        Assert.That(result, Is.EqualTo(expected));
    }
}
