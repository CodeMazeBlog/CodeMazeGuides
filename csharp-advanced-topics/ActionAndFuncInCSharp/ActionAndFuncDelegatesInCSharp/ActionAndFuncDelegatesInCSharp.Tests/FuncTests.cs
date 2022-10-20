using ActionAndFuncDelegatesInCSharp;

namespace ActionAndFunc.Tests;

public class FuncTests
{
    [Fact]
    public void GivenPositiveNumber_ShouldReturnNotNegativeAndNotZeroErrors()
    {
        //Arrange
        var number = 10;
        var sut = new RuleEngine();

        //Act
        var result = sut.ExecuteRules(number);

        //Assert
        Assert.Contains(result, x => x == "Given number is not Negative");
        Assert.Contains(result, x => x == "Given number is not Zero");
    }

    [Fact]
    public void GivenNegativeNumber_ShouldReturnNotPositiveAndNotZeroErrors()
    {
        //Arrange
        var number = -10;
        var sut = new RuleEngine();

        //Act
        var result = sut.ExecuteRules(number);

        //Assert
        Assert.Contains(result, x => x == "Given number is not Positive");
        Assert.Contains(result, x => x == "Given number is not Zero");
    }

    [Fact]
    public void GivenZeroNumber_ShouldReturnNotPositiveAndNotNegativeErrors()
    {
        //Arrange
        var number = 0;
        var sut = new RuleEngine();

        //Act
        var result = sut.ExecuteRules(number);

        //Assert
        Assert.Contains(result, x => x == "Given number is not Negative");
        Assert.Contains(result, x => x == "Given number is not Positive");
    }

}