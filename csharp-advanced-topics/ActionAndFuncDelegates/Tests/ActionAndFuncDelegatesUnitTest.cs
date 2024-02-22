using ActionAndFuncDelegates;

namespace Tests;
public class ActionAndFuncDelegatesUnitTest
{
    [Fact]
    public void WhenGreetUser_ThenPrintMessage()
    {
        //Arrange
        var output = new StringWriter();

        Console.SetOut(output);

        var name = "Dave";

        //Act
        ActionAndFunc.GreetUser(name);

        //Assert
        var expected = $"Hello {name}, welcome to the magnificent world of Action Delegates.";

        Assert.Equal(expected, output.ToString().Trim());
    }

    [Fact]
    public void WhenSquareNumber_ThenReturnCorrectValue()
    {
        //Arrange
        var input = 3;

        var expected = "9";

        //Act
        var actual = ActionAndFunc.SquareToString(input);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void WhenGetEvenSquaredNumbersAbove30_ThenReturnCorrectValues()
    {
        //Arrange
        var expected = new List<int> { 36, 64, 100 };

        //Act
        var actual = ActionAndFunc.GetEvenSquaredNumbersAbove30().ToList();

        //Assert
        Assert.Equal(expected, actual);
    }
}