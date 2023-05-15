namespace ActionAndFuncDelegatesInCSharp.Tests;

public class ActionDelegatesUnitTest : IDisposable
{
    private readonly StringWriter _stringWriter;

    public ActionDelegatesUnitTest()
    {
        _stringWriter = new StringWriter();
        Console.SetOut(_stringWriter);
    }

    public void Dispose()
    {
        _stringWriter.Dispose();
    }
    
    [Fact]
    public void WhenAddNumbersCalled_ThenDisplaySum()
    {
        // Arrange
        Action<int, int> addNumbers = ActionDelegates.AddNumbers;
        Console.SetOut(_stringWriter);
        // Act
        addNumbers(1, 10);
        
        // Assert
        string expectedResult = "The sum is: 11";
        string actualResult = _stringWriter.ToString().TrimEnd();
        Assert.Equal(expectedResult, actualResult);
    }
}