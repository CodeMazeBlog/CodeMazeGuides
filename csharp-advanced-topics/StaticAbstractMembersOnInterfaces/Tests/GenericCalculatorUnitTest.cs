namespace Tests;

public class GenericCalculatorUnitTest
{
    [Fact]
    public void GivenTwoUSDollarAmounts_WhenGenericCalculatorExecutesAddMethod_ThenResultIsAValidUSDollarAmount()
    {
        //Arrange
        var firstDollarAmount = new USDollar(1.2);
        var secondDollarAmount = new USDollar(3.8);
        var expectedDollarAmount = new USDollar(5.0);

        //Act
        var actualDollarAmount = GenericCalculator.Add(firstDollarAmount, secondDollarAmount);

        //Assert
        actualDollarAmount.Should().BeEquivalentTo(expectedDollarAmount);
    }

    [Fact]
    public void GivenTwoUSDollarAmounts_WhenGenericCalculatorExecutesSubtractMethod_ThenResultIsAValidUSDollarAmount()
    {
        //Arrange
        var firstDollarAmount = new USDollar(1.2);
        var secondDollarAmount = new USDollar(1.2);
        var expectedDollarAmount = USDollar.Zero;

        //Act
        var actualDollarAmount = GenericCalculator.Subtract(firstDollarAmount, secondDollarAmount);

        //Assert
        actualDollarAmount.Should().BeEquivalentTo(expectedDollarAmount);

    }

    [Fact]
    public void GivenTwoCanadianDollarAmounts_WhenGenericCalculatorExecutesAddMethod_ThenResultIsAValidCanadianDollarAmount()
    {
        //Arrange
        var firstDollarAmount = new CanadianDollar(1.2);
        var secondDollarAmount = new CanadianDollar(3.8);
        var expectedDollarAmount = new CanadianDollar(5.0);

        //Act
        var actualDollarAmount = GenericCalculator.Add(firstDollarAmount, secondDollarAmount);

        //Assert
        actualDollarAmount.Should().BeEquivalentTo(expectedDollarAmount);
    }

    [Fact]
    public void GivenTwoCanadianDollarAmounts_WhenGenericCalculatorExecutesSubtractMethod_ThenResultIsAValidCanadianDollarAmount()
    {
        //Arrange
        var firstDollarAmount = new CanadianDollar(1.2);
        var secondDollarAmount = new CanadianDollar(1.2);
        var expectedDollarAmount = CanadianDollar.Zero;

        //Act
        var actualDollarAmount = GenericCalculator.Subtract(firstDollarAmount, secondDollarAmount);

        //Assert
        actualDollarAmount.Should().BeEquivalentTo(expectedDollarAmount);

    }
}