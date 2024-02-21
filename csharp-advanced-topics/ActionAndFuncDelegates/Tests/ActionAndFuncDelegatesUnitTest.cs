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
        string name = "Dave";

        //Act
        ActionAndFunc.GreetUser(name);

        //Assert
        string expected = $"Hello {name}, welcome to the magnificent world of Action Delegates.";
        Assert.Equal(expected, output.ToString().Trim());
    }

    [Fact]
    public void WhenSquareNumber_ThenReturnCorrectValue()
    {
        //Arrange
        int input = 3;
        string expected = "9";

        //Act
        string actual = ActionAndFunc.SquareToString(input);

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