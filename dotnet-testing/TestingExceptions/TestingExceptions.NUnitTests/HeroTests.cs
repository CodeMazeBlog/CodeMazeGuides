namespace TestingExceptions.NUnitTests
{
    public class HeroTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenInsufficientExperience_WhenLevelUpIsInvoked_ThenExceptionIsThrown()
        {
            // Arrange
            var hero = new Hero(500);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(hero.LevelUp);
        }

        [Test]
        public void GivenInsufficientExperience_WhenLevelUpAsyncIsInvoked_ThenExceptionIsThrown()
        {
            // Arrange
            var hero = new Hero(500);

            // Assert
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(hero.LevelUpAsync);
        }
    }
}