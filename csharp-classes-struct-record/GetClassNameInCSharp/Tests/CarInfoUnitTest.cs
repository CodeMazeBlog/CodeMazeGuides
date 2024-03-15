namespace Tests;

public class CarInfoUnitTest
{
    [Fact]
    public void GivenCarInfoStaticClass_WhenDisplayClassNameWithTypeOfInvoked_ThenReturnCarInfo()
    {
        // Act
        var className = CarInfo.DisplayClassNameWithTypeOf();

        // Assert
        Assert.Equal("CarInfo", className);
    }

    [Fact]
    public void GivenCarInfoStaticClass_WhenDisplayClassNameWithNameOfInvoked_ThenReturnCarInfo()
    {
        // Act
        var className = CarInfo.DisplayClassNameWithNameOf();

        // Assert
        Assert.Equal("CarInfo", className);
    }

    [Fact]
    public void GivenCarInfoStaticClass_WhenNameOfInvoked_ThenReturnCarInfo()
    {
        // Act
        var className = nameof(CarInfo);

        // Assert
        Assert.Equal("CarInfo", className);
    }

    [Fact]
    public void GivenCarInfoStaticClass_WhenTypeOfInvoked_ThenReturnCarInfo()
    {
        // Act
        var className = typeof(CarInfo).Name;

        // Assert
        Assert.Equal("CarInfo", className);
    }
}
