using System;

namespace TestingExceptions.NUnitTests
{
    public class HeroTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenSufficientExperience_WhenLevelUpIsInvoked_ThenLeveIsIncreased()
        {
            // Arrange
            var hero = new Hero(1500);

            // Act
            hero.LevelUp();

            // Assert
            Assert.That(hero.Level, Is.EqualTo(1));
            Assert.That(hero.Experience, Is.EqualTo(500));
        }

        [Test]
        public void GivenInsufficientExperience_WhenLevelUpIsInvoked_ThenExceptionIsThrown()
        {
            // Arrange
            var hero = new Hero(500);

            // Act
            TestDelegate act = hero.LevelUp;

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(act);
            Assert.Throws<ArgumentOutOfRangeException>(hero.LevelUp);
        }

        [Test]
        public void GivenInsufficientExperience_WhenLevelUpAsyncIsInvoked_ThenExceptionIsThrown()
        {
            // Arrange
            var hero = new Hero(500);

            // Act
            AsyncTestDelegate act = hero.LevelUpAsync;

            // Assert
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(act);
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(hero.LevelUpAsync);
        }

        [Test]
        public void GivenInsufficientExperience_WhenLevelUpIsInvoked_ThenExceptionIsThrownWithCorrectMessage()
        {
            // Arrange
            var hero = new Hero(500);

            // Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(hero.LevelUp);

            // Assert
            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.Message, Is.EqualTo("Not enough Experience to level up! (Parameter 'Experience')"));
        }

        [Test]
        public void GivenInsufficientExperience_WhenLevelUpAsyncIsInvoked_ThenExceptionIsThrownWithCorrectMessage()
        {
            // Arrange
            var hero = new Hero(500);

            // Act
            var exception = Assert.ThrowsAsync<ArgumentOutOfRangeException>(hero.LevelUpAsync);

            // Assert
            Assert.That(exception, Is.Not.Null);
            Assert.That(exception.Message, Is.EqualTo("Not enough Experience to level up asynchronously! (Parameter 'Experience')"));
        }
    }
}