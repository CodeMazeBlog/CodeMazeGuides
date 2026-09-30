using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace QuartzVsHangfire.QuartzSample;

// Quartz.NET 4.x ships a dashboard of its own: a Blazor Server UI in the
// Quartz.Dashboard package, plus the execution history it reads.
public static class QuartzDashboardSetup
{
    public static IServiceCollection AddDashboard(this IServiceCollection services)
    {
        services.AddQuartzDashboard(options => options.ReadOnly = true);
        services.AddQuartzExecutionHistory(options => options.Retention = TimeSpan.FromHours(24));

        return services;
    }

    // In a web application this is the one mapping call the dashboard needs.
    public static IEndpointRouteBuilder MapDashboard(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapQuartzDashboard("/quartz");

        return endpoints;
    }
}
