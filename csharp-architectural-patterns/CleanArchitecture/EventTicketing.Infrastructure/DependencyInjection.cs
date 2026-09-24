using EventTicketing.Application.Abstractions;
using EventTicketing.Application.Events;
using EventTicketing.Infrastructure.Events;
using EventTicketing.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EventTicketing.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<TicketingDbContext>(options => options.UseSqlite(connectionString));

        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IEventReadRepository, EventReadRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
