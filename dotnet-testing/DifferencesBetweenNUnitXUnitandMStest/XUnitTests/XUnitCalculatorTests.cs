namespace XUnitTests;

[Trait("Category", "Calculator")]
public class XUnitCalculatorTests
{
    public static IEnumerable<object[]> TestData => new List<object[]> {
            new object[] { 3, 2, 1 },
            new object[] { 0, 0, 0 },
            new object[] { -2, 3, -5 },
    };

    [Fact]
    [Trait("Type", "Subtraction")]
    [Trait("Category", "Positive")]
    public void GivenTwoIntegers_WhenSubtracted_ThenShouldReturnDifference()
    {
        var result = Calculator.Subtract(7, 3);

        Assert.Equal(4, result);
    }

    [Fact]
    [Trait("Type", "Subtraction")]
    [Trait("Category", "Negative")]
    public void GivenTwoIntegers_WhenSubtracted_ThenShouldReturnCorrectNegativeDifference()
    {
        var result = Calculator.Subtract(-7, 3);

        Assert.Equal(-10, result);
    }

    [Theory]
    [InlineData(3, 2, 1)]
    [InlineData(0, 0, 0)]
    [InlineData(-2, 3, -5)]
    public void GivenTwoIntegers_WhenSubtracted_ThenReturnsDifferenceUsingInlineData(int a, int b, int expected)
    {
        var result = Calculator.Subtract(a, b);

        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void GivenTwoIntegers_WhenSubtracted_ThenReturnsDifferenceUsingMemberData(int a, int b, int expected)
    {
        var result = Calculator.Subtract(a, b);

        Assert.Equal(expected, result);
    }

    [Theory]
    [ClassData(typeof(XUnitTestDataGenerator))]
    public void GivenTwoIntegers_WhenSubtracted_ThenReturnsDifferenceUsingClassData(int a, int b, int expected)
    {
        var result = Calculator.Subtract(a, b);

        Assert.Equal(expected, result);
    }
}