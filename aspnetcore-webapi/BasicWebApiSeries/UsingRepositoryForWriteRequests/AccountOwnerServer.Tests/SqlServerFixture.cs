using Entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using Testcontainers.MsSql;

namespace AccountOwnerServer.Tests
{
    // Starts one SQL Server container for the whole test class and creates the schema by
    // running the same init.sql part 1 ships. Nothing here calls EnsureCreated: the script
    // is the only thing that creates the schema, in the tests as in the article.
    public class SqlServerFixture : IAsyncLifetime
    {
        private MsSqlContainer? _container;

        public string ConnectionString { get; private set; } = string.Empty;

        public async Task InitializeAsync()
        {
            if (!DockerEnvironment.IsAvailable.Value)
            {
                return;
            }

            _container = new MsSqlBuilder("mcr.microsoft.com/mssql/server:2022-latest").Build();
            await _container.StartAsync();

            var script = await File.ReadAllTextAsync("init.sql");
            var result = await _container.ExecScriptAsync(script);
            if (result.ExitCode != 0)
            {
                throw new InvalidOperationException($"init.sql failed: {result.Stderr}");
            }

            ConnectionString = _container.GetConnectionString()
                .Replace("Database=master", "Database=AccountOwner");
        }

        public async Task DisposeAsync()
        {
            if (_container is not null)
            {
                await _container.DisposeAsync();
            }
        }

        public RepositoryContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlServer(ConnectionString)
                .Options;

            return new RepositoryContext(options);
        }

        public RepositoryWrapper CreateWrapper() => new(CreateContext());
    }
}
