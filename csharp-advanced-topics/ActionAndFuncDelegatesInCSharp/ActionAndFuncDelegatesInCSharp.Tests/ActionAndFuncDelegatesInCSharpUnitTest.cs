namespace ActionAndFuncDelegatesInCSharp.Tests;

public class ActionAndFuncDelegatesInCSharpUnitTest
{
    [Fact]
    public void WhenActionDelegateIsUsed_ThenItShouldBeExecuted()
    {
        // Arrange
        Action displayMessage = () => Console.WriteLine("Hello, C#!");

        // Act
        displayMessage();

        // Assert
        Assert.True(true);
    }

    [Fact]
    public void WhenFuncDelegateIsUsed_ThenItShouldBeExecutedAndReturnProperResult()
    {
        // Arrange
        Func<int> getRandomNumber = () => new Random().Next(minValue: 1, maxValue: 100);

        // Act
        var randomNumber = getRandomNumber();

        // Assert
        Assert.True(condition: randomNumber is >= 1 and < 100);
    }
}