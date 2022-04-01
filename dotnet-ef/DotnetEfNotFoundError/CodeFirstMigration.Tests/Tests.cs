using Xunit;

namespace CodeFirstMigration.Tests
{
    public class Tests
    {
        [Fact]
        public void TestSQLiteOk()
        {
            //arrange
            using var context = new CustomerContext();

            //act & assert

            context.Database.EnsureCreated();
        }
    }
}
