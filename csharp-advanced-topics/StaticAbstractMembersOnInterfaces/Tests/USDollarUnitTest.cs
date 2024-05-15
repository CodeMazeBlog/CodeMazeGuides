namespace Tests;

public class USDollarUnitTest
{
    [Fact]
    public void WhenADoubleAmountIsPassedToConsutructor_ThenUSDollarInstanceCanBeCreatedWithValidState()
    {
        //Arrange
        var expectedValue = 2.2;

        //Act
        var dollarAmount = new USDollar(2.2);

        //Assert
        dollarAmount.Value.Should().Be(expectedValue);
    }

    [Fact]
    public void WhenTwoUSDollarAmountsAreAdded_ThenResultantSumIsRepresentedByAValidAmount()
    {
        //Arrange
        var expectedDollarAmount = new USDollar(1.2);
        var firstDollarAmount = new USDollar(1.0);
        var secondDollarAmount = new USDollar(0.2);

        //Act
        var additionResult = firstDollarAmount + secondDollarAmount;

        //Assert
        additionResult.Should().BeEquivalentTo(expectedDollarAmount);
    }

    [Fact]
    public void WhenTwoUSDollarAmountsAreSubtracted_ThenResultantDifferenceIsRepresentedByAValidAmount()
    {
        //Arrange
        var expectedDollarAmount = new USDollar(1.2);
        var firstDollarAmount = new USDollar(2.0);
        var secondDollarAmount = new USDollar(0.8);

        //Act
        var subtractionResult = firstDollarAmount - secondDollarAmount;

        //Assert
        subtractionResult.Should().BeEquivalentTo(expectedDollarAmount);
    }

    [Fact]
    public void WhenAZeroRepresentationOfUSDollarIsRequired_ThenUsDollarTypeProvidesTheRepresentation()
    {
        //Arrange
        var expectedZeroDollarAmount = new USDollar(0.0);

        //Act
        var actualDollarAmount = USDollar.Zero;

        //Assert
        actualDollarAmount.Should().BeEquivalentTo(expectedZeroDollarAmount);
    }
}