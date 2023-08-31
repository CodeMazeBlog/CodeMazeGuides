namespace Tests;

public class ActionFuncTests
{
    [Fact]
    public void AdditionTest()
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        int result = calculator.Add(5, 3);

        // Assert
        Assert.Equal(8, result);
    }
}