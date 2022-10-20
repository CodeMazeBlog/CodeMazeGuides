namespace ActionAndFunc.Tests;

public class FuncTests
{
    [Fact]
    public void GivenPositiveNumber_ShouldReturnTrue()
    {
        //Arrange
        var number = 10;
        var sut = new RuleEngine();
        
        //Act
        var isPositiveNumber = sut.Rules["PositiveNumber"](number);

        //Assert
        Assert.True(isPositiveNumber);
    }
    
    [Fact]
    public void GivenNegativeNumber_ShouldReturnFalse()
    {
        //Arrange
        var number = -10;
        var sut = new RuleEngine();
        
        //Act
        var isPositiveNumber = sut.Rules["PositiveNumber"](number);

        //Assert
        Assert.False(isPositiveNumber);
    }
    
    [Fact]
    public void GivenNegativeNumber_ShouldReturnTrue()
    {
        //Arrange
        var number = -10;
        var sut = new RuleEngine();
        
        //Act
        var isNegativeNumber = sut.Rules["NegativeNumber"](number);

        //Assert
        Assert.True(isNegativeNumber);
    }
    
    [Fact]
    public void GivenPositiveNumber_ShouldReturnFalse()
    {
        //Arrange
        var number = 10;
        var sut = new RuleEngine();
        
        //Act
        var isNegativeNumber = sut.Rules["NegativeNumber"](number);

        //Assert
        Assert.False(isNegativeNumber);
    }
}