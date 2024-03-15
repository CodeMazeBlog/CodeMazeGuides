namespace UniqueConstraintsInEFCore.Tests;

public class SolarSystemApiApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly MsSqlContainer _msSqlContainer = new MsSqlBuilder().Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptions<SolarSystemDbContext>));
            services.AddDbContext<SolarSystemDbContext>(options =>
                options.UseSqlServer(_msSqlContainer.GetConnectionString()));
        });
    }

    public Task InitializeAsync()
         => _msSqlContainer.StartAsync();

    Task IAsyncLifetime.DisposeAsync()
        => _msSqlContainer.DisposeAsync().AsTask();
}