namespace TestingExceptions.xUnitTests
{
    public class HeroTests
    {
        [Fact]
        public void GivenSufficientExperience_WhenLevelUpIsInvoked_ThenLeveIsIncreased()
        {
            // Arrange
            var hero = new Hero(1500);

            // Act
            hero.LevelUp();

            // Assert
            Assert.Equal(1, hero.Level);
            Assert.Equal(500, hero.Experience);
        }

        [Fact]
        public void GivenInsufficientExperience_WhenLevelUpIsInvoked_ThenExceptionIsThrown()
        {
            // Arrange
            var hero = new Hero(500);

            // Act
            Action act = () => hero.LevelUp();

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Fact]
        public void GivenInsufficientExperience_WhenLevelUpAsyncIsInvoked_ThenExceptionIsThrown()
        {
            // Arrange
            var hero = new Hero(500);

            // Act
            async Task act() => await hero.LevelUpAsync();

            // Assert
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(act);
        }
    }
}