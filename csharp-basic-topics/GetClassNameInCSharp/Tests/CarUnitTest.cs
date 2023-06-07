namespace Tests;

public class CarUnitTest
{
    [Fact]
    public void GivenCarInstance_WhenDisplayClassNameWithGetTypeInvoked_ThenReturnCar()
    {
        // Arrange
        var car = new Car();

        // Act
        var className = car.DisplayClassNameWithGetType();

        // Assert
        Assert.Equal("Car", className);
    }

    [Fact]
    public void GivenCarInstance_WhenDisplayClassNameWithTypeOfInvoked_ThenReturnCar()
    {
        // Arrange
        var car = new Car();

        // Act
        var className = car.DisplayClassNameWithTypeOf();

        // Assert
        Assert.Equal("Car", className);
    }

    [Fact]
    public void GivenCarInstance_WhenDisplayClassNameWithNameOfInvoked_ThenReturnCar()
    {
        // Arrange
        var car = new Car();

        // Act
        var className = car.DisplayClassNameWithNameOf();

        // Assert
        Assert.Equal("Car", className);
    }

    [Fact]
    public void GivenCarClass_WhenTypeOfInvoked_ThenReturnCar()
    {
        // Act
        var className = typeof(Car).Name;

        // Assert
        Assert.Equal("Car", className);
    }

    [Fact]
    public void GivenCarClass_WhenNameOfInvoked_ThenReturnCar()
    {
        // Act
        var className = nameof(Car);

        // Assert
        Assert.Equal("Car", className);
    }

    [Fact]
    public void GivenCarInstance_WhenDisplayClassNameWithReflectionInvoked_ThenReturnCar()
    {
        // Arrange
        var car = new Car();

        // Act
        var className = car.DisplayClassNameWithReflection();

        // Assert
        Assert.Equal("Car", className);
    }
}
