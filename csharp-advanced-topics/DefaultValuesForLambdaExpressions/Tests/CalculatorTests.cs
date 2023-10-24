namespace Tests;

public class CalculatorTests
{
    [Fact]
    public void GivenAValue_WhenIncrementValueProvided_ThenReturnsTheSumOfTheArguments()
    {
        Assert.Equal(15, Calculator.IncrementByValue(10, 5));
    }

    [Fact]
    public void GivenAValue_WhenIncrementValueNotProvided_ThenIncrementsUsingDefaultValue()
    {
        Assert.Equal(11, Calculator.IncrementByDefaultValue(10));
    }

    [Fact]
    public void GivenAListOfInt_WhenSum_ThenReturnsTheTotal()
    {
        Assert.Equal(150, Calculator.Total(10, 20, 30, 40, 50));
    }

    [Fact]
    public void GivenAnEmptyIntegerList_WhenSum_ThenReturnsZero()
    {
        Assert.Equal(0, Calculator.Total());
    }
}