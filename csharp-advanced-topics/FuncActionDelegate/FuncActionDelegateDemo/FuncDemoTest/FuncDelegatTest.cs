namespace FuncDemoTest;

public class FuncDelegatTest
{
    [Fact]
    public void SumOfEvens_ShouldBeCorrect()
    {
        // Arrange
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Func<int, bool> isEven = n => n % 2 == 0;

        // Act
        int sumOfEvens = numbers.Where(isEven).Sum();

        // Assert
        Assert.Equal(30, sumOfEvens);
    }
}