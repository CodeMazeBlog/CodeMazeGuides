using EFCoreBulkUpdate;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class TestDatabaseFixture : IDisposable
    {
        private readonly string _connectionString;

        private readonly DbContextOptions<TeamDBContext> _options;

        public TestDatabaseFixture()
        {
            var dbName = Guid.NewGuid().ToString();

            _connectionString = $"server=.; Initial Catalog=TeamDB_{dbName};User ID=sa;Password=123;TrustServerCertificate=True;";

            _options = new DbContextOptionsBuilder<TeamDBContext>()
                .UseSqlServer(_connectionString)
                .Options;
            using (var context = new TeamDBContext(_options))
            {
                context.Database.EnsureCreated();
            }
        }

        public TeamDBContext CreateContext()
        {
            return new TeamDBContext(_options);
        }

        public void Dispose()
        {
            using (var context = new TeamDBContext(_options))
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}