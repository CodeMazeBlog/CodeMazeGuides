using DTS_Project.Application.Configurations.Helpers;
using FanIn_Fan_out.Functions;
using FanIn_Fan_out.Functions.Configurations.Options;
using FanIn_Fan_out.Shared.Application.Services;
using FanIn_Fan_out.Shared.Domain.Interfaces;
using FanIn_Fan_out.Shared.Infrastructure.DatabaseContext;
using Lab_Fan_out_Fan_in_Fonctions_Durables.Repositories;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DurableFunctionsMonitor.DotNetBackend;

[assembly: FunctionsStartup(typeof(Startup))]
namespace FanIn_Fan_out.Functions;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        IConfiguration configuration = builder.GetContext().Configuration;

        builder.Services.AddDbContext<AdventureWorks2012Context>(options =>
                options.UseSqlServer(configuration.GetConnectionString(ConfigurationSections.Database)));
        builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
        builder.Services.AddOptions().Configure<FeatureFlagsOptions>(configuration.GetSection(ConfigurationSections.FeatureFlagsOptions));

        FeatureFlagsOptions featureFlags = new();
        configuration.GetSection(ConfigurationSections.FeatureFlagsOptions).Bind(featureFlags);
        if (featureFlags.EnableMonitor)
        {
            DfmEndpoint.Setup(new DfmSettings { DisableAuthentication = true });
        }

        builder.Services.AddTransient<IProductRepository, ProductRepository>();
        builder.Services.AddTransient<IProductService, ProductService>();
    }
}