namespace Tests;

public class CarInfoUnitTest
{
    [Fact]
    public void WhenDisplayClassNameWithTypeOfInvoked_ThenReturnCarInfo()
    {
        // Act
        string className = CarInfo.DisplayClassNameWithTypeOf();

        // Assert
        Assert.Equal("CarInfo", className);
    }

    [Fact]
    public void WhenDisplayClassNameWithNameOfInvoked_ThenReturnCarInfo()
    {
        // Act
        string className = CarInfo.DisplayClassNameWithNameOf();

        // Assert
        Assert.Equal("CarInfo", className);
    }
}
