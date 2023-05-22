namespace Tests;

public class CarUnitTest
{
    [Fact]
    public void GivenCarInstance_WhenDisplayClassNameWithGetTypeInvoked_ThenReturnCar()
    {
        // Arrange
        var car = new Car();

        // Act
        string className = car.DisplayClassNameWithGetType();

        // Assert
        Assert.Equal("Car", className);
    }

    [Fact]
    public void GivenCarInstance_WhenDisplayClassNameWithTypeOfInvoked_ThenReturnCar()
    {
        // Arrange
        var car = new Car();

        // Act
        string className = car.DisplayClassNameWithTypeOf();

        // Assert
        Assert.Equal("Car", className);
    }

    [Fact]
    public void GivenCarInstance_WhenDisplayClassNameWithNameOfInvoked_ThenReturnCar()
    {
        // Arrange
        var car = new Car();

        // Act
        string className = car.DisplayClassNameWithNameOf();

        // Assert
        Assert.Equal("Car", className);
    }

    [Fact]
    public void GivenCarInstance_WhenDisplayClassNameWithReflectionInvoked_ThenReturnCar()
    {
        // Arrange
        var car = new Car();

        // Act
        string? className = car.DisplayClassNameWithReflection();

        // Assert
        Assert.Equal("Car", className);
    }
}
