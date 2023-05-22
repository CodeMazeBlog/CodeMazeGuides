using FluentAssertions;

namespace InitSetters.Tests
{
    public class CityTests
    {
        private readonly string _name = "Tokyo";
        private readonly double _lat = 139.839478;
        private readonly double _lon = 35.652832;

        [Fact]
        public void WhenConstructorIsInvoked_ThenValidObjectIsReturned()
        {
            // Act
            var city = new City(_name, _lat, _lon);

            // Assert
            city.Name.Should().Be(_name);
            city.Latitude.Should().Be(_lat);
            city.Longitude.Should().Be(_lon);
        }

        [Fact]
        public void WhenChangeNameIsInvoked_ThenNameIsChanged()
        {
            // Arrange
            var newName = "Edo";
            var city = new City(_name, _lat, _lon);

            // Act
            city.ChangeName(newName);

            // Assert
            city.Name.Should().Be(newName);
        }
    }
}