using CodeFirstMigration;
using Xunit;

namespace Tests
{
    public class ExampleTests
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