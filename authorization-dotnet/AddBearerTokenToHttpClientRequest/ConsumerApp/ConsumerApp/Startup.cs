using ConsumerApp.Application.cs;
using ConsumerApp.Domain.Interfaces;
using ConsumerApp.Infrastructure;
using ConsumerApp.Infrastructure.Repository.Handler;
using ConsumerApp.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsumerApp
{
    public class StartUp
    {
        public IHost HostBuild()
        {
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddScoped<ProgramApplication>();

                    services.AddHttpClient<ILoginApiRepository, LoginApiRepository>(
                        c => c.BaseAddress = new Uri("https://localhost:5001/"));
                    
                    services.AddScoped<LoginHandler>();

                    services.AddHttpClient<IUserApiRepository, UserApiRepository>(
                        c => c.BaseAddress = new Uri("https://localhost:5001/"))
                        .AddHttpMessageHandler<LoginHandler>();
                    
                }).UseConsoleLifetime();

            return builder.Build();
        }
    }
}
