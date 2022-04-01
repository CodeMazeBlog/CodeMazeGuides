using Xunit;

namespace CodeFirstMigration.Tests
{
    public class Tests
    {
        [Fact]
        public void GivenContext_WhenMigrate_ThenEnsureDbCreated()
        {
            //arrange
            using var context = new CustomerContext();

            //act & assert

            context.Database.EnsureCreated();
        }
    }
}
