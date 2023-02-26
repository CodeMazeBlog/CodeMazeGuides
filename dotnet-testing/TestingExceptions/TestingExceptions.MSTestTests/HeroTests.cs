namespace TestingExceptions.MSTestTests
{
    [TestClass]
    public class HeroTests
    {
        [TestMethod]
        public void GivenSufficientExperience_WhenLevelUpIsInvoked_ThenLeveIsIncreased()
        {
            // Arrange
            var hero = new Hero(1500);

            // Act
            hero.LevelUp();

            // Assert
            Assert.AreEqual(1, hero.Level);
            Assert.AreEqual(500, hero.Experience);
        }

        [TestMethod]
        public void GivenInsufficientExperience_WhenLevelUpIsInvoked_ThenExceptionIsThrown()
        {
            // Arrange
            var hero = new Hero(500);

            // Act
            Action act = () => hero.LevelUp();

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(act);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => hero.LevelUp());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GivenInsufficientExperience_WhenLevelUpIsInvoked_ThenExceptionIsThrownWithoutAssert()
        {
            // Arrange
            var hero = new Hero(500);

            // Act
            hero.LevelUp();
        }

        [TestMethod]
        public async Task GivenInsufficientExperience_WhenLevelUpAsyncIsInvoked_ThenExceptionIsThrown()
        {
            // Arrange
            var hero = new Hero(500);

            // Act
            Func<Task> act = hero.LevelUpAsync;

            // Assert
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(act);
        }
    }
}