using FluentAssertions;

namespace Guard_Clauses.Tests
{
    public class CarTests
    {
        [Fact]
        public void GivenValidEngine_WhenConstructorIsInvoked_ThenEngineIsAssignedToProperty()
        {
            // Arrange
            var engine = new Engine(150, 4, "Inline", 250, FuelType.Diesel);

            // Act
            var car = new Car(engine);

            // Assert
            car.Engine.Should().BeEquivalentTo(engine);
        }

        [Fact]
        public void GivenInvalidEngine_WhenConstructorIsInvoked_ThenArgumentNullExceptionsIsThrown()
        {
            // Arrange
            var engine = (Engine)null;

            // Act
            Action action = () => new Car(engine);

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }
    }
}
