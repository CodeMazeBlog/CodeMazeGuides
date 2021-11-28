global using ActionAndFuncDelegates;
using Xunit;

namespace ActionAndFuncDelegatesTest;

public class Tests
{
    [Theory]
    [InlineData(10, 20, 200)]
    [InlineData(1, 5, 5)]
    [InlineData(0, 20, 0)]
    public void CalculateRectangleArea(uint length, uint breadth, ulong expectedArea)
    {
        //Act
        var actualArea = Rectangle.CalculateArea(length, breadth);

        //Assert
        Assert.IsType<ulong>(actualArea);
        Assert.Equal(expectedArea, actualArea);
    }

    [Fact]
    public void MainMethodRunsWithoutException() => Program.Main(null); // if no exception, test will pass        
}