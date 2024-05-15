namespace Tests;

public class CanadianDollarUnitTest
{
    [Fact]
    public void WhenADoubleAmountIsPassedToConsutructor_ThenCanadianDollarInstanceCanBeCreatedWithValidState()
    {
        //Arrange
        var expectedValue = 2.2;

        //Act
        var dollarAmount = new CanadianDollar(2.2);

        //Assert
        dollarAmount.Value.Should().Be(expectedValue);
    }

    [Fact]
    public void WhenTwoCanadianDollarAmountsAreAdded_ThenResultantSumIsRepresentedByAValidAmount()
    {
        //Arrange
        var expectedDollarAmount = new CanadianDollar(1.2);
        var firstDollarAmount = new CanadianDollar(1.0);
        var secondDollarAmount = new CanadianDollar(0.2);

        //Act
        var additionResult = firstDollarAmount + secondDollarAmount;

        //Assert
        additionResult.Should().BeEquivalentTo(expectedDollarAmount);
    }

    [Fact]
    public void WhenTwoCanadianDollarAmountsAreSubtracted_ThenResultantDifferenceIsRepresentedByAValidAmount()
    {
        //Arrange
        var expectedDollarAmount = new CanadianDollar(1.2);
        var firstDollarAmount = new CanadianDollar(2.0);
        var secondDollarAmount = new CanadianDollar(0.8);

        //Act
        var subtractionResult = firstDollarAmount - secondDollarAmount;

        //Assert
        subtractionResult.Should().BeEquivalentTo(expectedDollarAmount);
    }

    [Fact]
    public void WhenAZeroRepresentationOfCanadianDollarIsRequired_ThenCanadianDollarTypeProvidesTheRepresentation()
    {
        //Arrange
        var expectedZeroDollarAmount = new CanadianDollar(0.0);

        //Act
        var actualDollarAmount = CanadianDollar.Zero;

        //Assert
        actualDollarAmount.Should().BeEquivalentTo(expectedZeroDollarAmount);
    }
}