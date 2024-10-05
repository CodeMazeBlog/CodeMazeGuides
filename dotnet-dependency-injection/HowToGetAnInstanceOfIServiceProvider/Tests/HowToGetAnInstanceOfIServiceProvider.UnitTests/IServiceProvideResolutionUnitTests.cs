namespace HowToGetAnInstanceOfIServiceProvider.UnitTests;

using Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Services;
using Xunit;

public class IServiceProvideResolutionUnitTests
{
    [Fact]
    public void GivenDevelopmentEnvironment_WhenServiceIsResolved_ThenShouldReturnDevelopmentExampleService()
    {
        // Arrange
        var services = new ServiceCollection();

        services.AddSingleton<IHostEnvironment>(new HostingEnvironment { EnvironmentName = Environments.Development });

        services.AddScoped<IExampleService>(serviceProvider =>
        {
            var config = serviceProvider.GetRequiredService<IHostEnvironment>();
            return config.IsDevelopment() ? new DevelopmentExampleService() : new ExampleService();
        });

        var serviceProvider = services.BuildServiceProvider();

        // Act
        var exampleService = serviceProvider.GetService<IExampleService>();

        // Assert
        Assert.IsType<DevelopmentExampleService>(exampleService);
    }

    [Fact]
    public void GivenProductionEnvironment_WhenServiceIsResolved_ThenShouldReturnExampleService()
    {
        // Arrange
        var services = new ServiceCollection();

        services.AddSingleton<IHostEnvironment>(new HostingEnvironment { EnvironmentName = Environments.Production });

        services.AddScoped<IExampleService>(serviceProvider =>
        {
            var config = serviceProvider.GetRequiredService<IHostEnvironment>();
            return config.IsDevelopment() ? new DevelopmentExampleService() : new ExampleService();
        });

        var serviceProvider = services.BuildServiceProvider();

        // Act
        var exampleService = serviceProvider.GetService<IExampleService>();

        // Assert
        Assert.IsType<ExampleService>(exampleService);
    }

    [Fact]
    public async Task GivenBackgroundService_WhenStartAsyncIsCalled_ThenShouldNotThrowException()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddScoped<IExampleService, ExampleService>();
        var serviceProvider = services.BuildServiceProvider();

        var backgroundService = new ExampleBackgroundService(serviceProvider);

        // Act
        var exception = await Record.ExceptionAsync(() => backgroundService.StartAsync(CancellationToken.None));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void GivenHttpContext_WhenServiceIsResolvedFromHttpContext_ThenShouldReturnOkWithServiceResolved()
    {
        // Arrange
        var services = new ServiceCollection();

        services.AddScoped<IExampleService, ExampleService>();

        var serviceProvider = services.BuildServiceProvider();
        var httpContext = new DefaultHttpContext();

        httpContext.Features.Set<IServiceProvidersFeature>(new ServiceProvidersFeature { RequestServices = serviceProvider });

        var controller = new ExampleController
        {
            ControllerContext = new ControllerContext
            {
                HttpContext = httpContext
            }
        };

        // Act
        var result = controller.GetIServiceProviderFromHttpContext() as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Value);
        Assert.True((bool)result.Value);
    }
}