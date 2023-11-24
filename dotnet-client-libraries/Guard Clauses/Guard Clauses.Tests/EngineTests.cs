using FluentAssertions;

namespace Guard_Clauses.Tests
{
    public class EngineTests
    {
        [Fact]
        public void GivenInvalidHorsePower_WhenConstructorIsInvoked_ThenArgumentExceptionsIsThrown()
        {
            // Arrange
            var horsePower = -1;

            // Act
            Action action = () => new Engine(horsePower, 4, "Inline", 250, FuelType.Diesel);

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void GivenInvalidCylinders_WhenConstructorIsInvoked_ThenArgumentExceptionsIsThrown()
        {
            // Arrange
            var cylinders = 0;

            // Act
            Action action = () => new Engine(150, cylinders, "Inline", 250, FuelType.Diesel);

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void GivenInvalidCylinderLayout_WhenConstructorIsInvoked_ThenArgumentExceptionsIsThrown()
        {
            // Arrange
            var cylinderLayout = string.Empty;

            // Act
            Action action = () => new Engine(150, 4, cylinderLayout, 250, FuelType.Diesel);

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void GivenInvalidTopSpeed_WhenConstructorIsInvoked_ThenArgumentExceptionsIsThrown()
        {
            // Arrange
            var topSpeed = 0;

            // Act
            Action action = () => new Engine(150, 4, "Inline", topSpeed, FuelType.Diesel);

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void GivenInvalidFuelType_WhenConstructorIsInvoked_ThenArgumentExceptionsIsThrown()
        {
            // Arrange
            var fuelType = FuelType.Petrol;

            // Act
            Action action = () => new Engine(150, 4, "Inline", 250, fuelType);

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void GivenValidParameters_WhenConstructorIsInvoked_ThenEngineIsProperlyCreated()
        {
            // Arrange
            var horsePower = 150;
            var cylinders = 4;
            var cylinderLayout = "Inline";
            var topSpeed = 250;
            var fuelType = FuelType.Diesel;

            // Act
            var engine = new Engine(horsePower, cylinders, cylinderLayout, topSpeed, fuelType);

            // Assert
            engine.HorsePower.Should().Be(horsePower);
            engine.Cylinders.Should().Be(cylinders);
            engine.CylinderLayout.Should().Be(cylinderLayout);
            engine.TopSpeed.Should().Be(topSpeed);
            engine.FuelType.Should().Be(fuelType);
        }
    }
}
