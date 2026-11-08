namespace InitSetters.Tests
{
    public class CityTests
    {
        private readonly string _name = "Tokyo";
        private readonly double _lat = 35.652832;
        private readonly double _lon = 139.839478;

        [Fact]
        public void WhenConstructorIsInvoked_ThenValidObjectIsReturned()
        {
            // Act
            var city = new City(_name, _lat, _lon);

            // Assert
            Assert.Equal(_name, city.Name);
            Assert.Equal(_lat, city.Latitude);
            Assert.Equal(_lon, city.Longitude);
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
            Assert.Equal(newName, city.Name);
        }

        [Fact]
        public void WhenSetPropertyIsAssignedAfterCreation_ThenValueChanges()
        {
            // Arrange
            var landmark = new Landmark { Name = "Senso-ji", City = "Tokyo" };

            // Act
            landmark.Name = "Senso-ji Temple";

            // Assert
            Assert.Equal("Senso-ji Temple", landmark.Name);
            Assert.Equal("Tokyo", landmark.City);
        }

        [Fact]
        public void WhenRequiredPropertyIsSet_ThenObjectIsCreated()
        {
            // Act
            var japan = new Country { Name = "Japan", Capital = "Tokyo" };

            // Assert
            Assert.Equal("Japan", japan.Name);
            Assert.Equal("Tokyo", japan.Capital);
        }

        [Fact]
        public void WhenWithExpressionIsUsed_ThenOriginalIsUnchanged()
        {
            // Arrange
            var tokyo = new Coordinates(35.652832, 139.839478);

            // Act
            var tower = tokyo with { Latitude = 35.658581, Longitude = 139.745438 };

            // Assert
            Assert.Equal(35.652832, tokyo.Latitude);
            Assert.Equal(35.658581, tower.Latitude);
            Assert.NotSame(tokyo, tower);
        }

        [Fact]
        public void WhenObjectInitializerFollowsPrimaryConstructor_ThenInitializerWins()
        {
            // Act
            var haneda = new Airport("HND", "Haneda") { Name = "Tokyo International" };

            // Assert
            Assert.Equal("HND", haneda.Code);
            Assert.Equal("Tokyo International", haneda.Name);
        }
    }
}
