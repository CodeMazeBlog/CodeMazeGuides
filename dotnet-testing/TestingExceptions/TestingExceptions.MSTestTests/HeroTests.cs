namespace TestingExceptions.MSTestTests
{
    [TestClass]
    public class HeroTests
    {
        [TestMethod]
        public void GivenInsufficientExperience_WhenLevelUpIsInvoked_ThenExceptionIsThrown()
        {
            // Arrange
            var hero = new Hero(500);

            // Act
            Action act = () => hero.LevelUp();

            Assert.ThrowsException<ArgumentOutOfRangeException>(act);
        }

        [TestMethod]
        public async Task GivenInsufficientExperience_WhenLevelUpAsyncIsInvoked_ThenExceptionIsThrown()
        {
            // Arrange
            var hero = new Hero(500);

            // Act
            Func<Task> act = hero.LevelUpAsync;

            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(act);
        }
    }
}