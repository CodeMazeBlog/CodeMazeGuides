using AccountOwnerServer.Filters;
using Contracts;
using Entities.Helpers;
using Entities.Models;
using Entities;
using LoggerService;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using System.Linq;

namespace AccountOwnerServer.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
            options.AddPolicy("CorsPolicy",
                builder => builder.WithOrigins("http://localhost:5000", "https://localhost:5001")
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials()
                   .WithExposedHeaders("X-Pagination")));

    public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddSingleton<ILoggerManager, LoggerManager>();

    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config["sqlconnection:connectionString"];
        services.AddDbContext<RepositoryContext>(o => o.UseSqlServer(connectionString));
    }

    public static void ConfigureRepositoryWrapper(this IServiceCollection services)
    {
        services.AddScoped<ISortHelper<Owner>, SortHelper<Owner>>();
        services.AddScoped<ISortHelper<Account>, SortHelper<Account>>();

        services.AddSingleton<IDataShaper<Owner>, DataShaper<Owner>>();
        services.AddSingleton<IDataShaper<Account>, DataShaper<Account>>();
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
    }

    public static void RegisterFilters(this IServiceCollection services) =>
        services.AddScoped<ValidateMediaTypeAttribute>();

    public static void AddCustomMediaTypes(this IServiceCollection services)
    {
        services.Configure<MvcOptions>(config =>
        {
            var systemTextJsonOutputFormatter = config.OutputFormatters
                .OfType<SystemTextJsonOutputFormatter>().FirstOrDefault();

            systemTextJsonOutputFormatter?.SupportedMediaTypes
                .Add("application/vnd.codemaze.hateoas+json");

            var xmlOutputFormatter = config.OutputFormatters
                .OfType<XmlDataContractSerializerOutputFormatter>().FirstOrDefault();

            xmlOutputFormatter?.SupportedMediaTypes
                .Add("application/vnd.codemaze.hateoas+xml");
        });
    }
}
