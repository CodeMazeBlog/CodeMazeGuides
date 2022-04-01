using CodeFirstMigration;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Tests
{
    public class ExampleTests
    {
        [Fact]
        public void GivenContext_WhenMigrate_ThenReturnsNoError()
        {
            //arrange
            using var context = new CustomerContext();

            //act & assert

            context.Database.Migrate();
        }
    }
}