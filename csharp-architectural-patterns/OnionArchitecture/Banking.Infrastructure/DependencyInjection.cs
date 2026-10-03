using Banking.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Banking.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<BankingDbContext>(options => options.UseSqlite(connectionString));
        services.AddScoped<IAccountRepository, AccountRepository>();

        return services;
    }
}
