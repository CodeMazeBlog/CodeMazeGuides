using FluentAssertions;

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
            Assert.Throws<ArgumentOutOfRangeException>(() => hero.LevelUp());
        }

        [Fact]
        public async Task GivenInsufficientExperience_WhenLevelUpAsyncIsInvoked_ThenExceptionIsThrown()
        {
            // Arrange
            var hero = new Hero(500);

            // Act
            Func<Task> act = () => hero.LevelUpAsync();

            // Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(act);
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(hero.LevelUpAsync);
        }

        [Fact]
        public void GivenInsufficientExperience_WhenLevelUpIsInvoked_ThenExceptionIsThrownWithCorrectMessage()
        {
            // Arrange
            var hero = new Hero(500);

            // Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => hero.LevelUp());

            // Assert
            Assert.NotNull(exception);
            Assert.Equal("Not enough Experience to level up! (Parameter 'Experience')", exception.Message);
        }

        [Fact]
        public async Task GivenInsufficientExperience_WhenLevelUpAsyncIsInvoked_ThenExceptionIsThrownWithCorrectMessage()
        {
            // Arrange
            var hero = new Hero(500);

            // Act
            var exception = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(hero.LevelUpAsync);

            // Assert
            Assert.NotNull(exception);
            Assert.Equal("Not enough Experience to level up asynchronously! (Parameter 'Experience')", exception.Message);
        }

        [Fact]
        public async Task GivenInsufficientExperience_WhenLevelUpIsInvoked_ThenExceptionIsThrownWithFluentAssertions()
        {
            // Arrange
            var hero = new Hero(500);

            // Act
            Action actSync = () => hero.LevelUp();
            Func<Task> actAsync = () => hero.LevelUpAsync();

            // Assert
            actSync.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage("Not enough Experience to level up! (Parameter 'Experience')");

            await actAsync.Should().ThrowAsync<ArgumentOutOfRangeException>()
                .WithMessage("Not enough Experience to level up asynchronously! (Parameter 'Experience')");
        }
    }
}