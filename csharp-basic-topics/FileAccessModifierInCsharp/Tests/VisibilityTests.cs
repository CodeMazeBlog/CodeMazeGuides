namespace Tests
{
    public class VisibilityTests
    {
        [Fact]
        public void WhenCheckingAssemblyTypes_ThenLoggerClassIsNotAccessible()
        {
            // Given: Initial context setup (omitted in this case)

            // When: Action that triggers the behavior
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .ToList();

            // Then: Expected outcome
            var loggerType = types.FirstOrDefault(t => t.Name == "Logger");
            Assert.Null(loggerType);  // Logger should not be accessible, so loggerType should be null
        }
    }
}
