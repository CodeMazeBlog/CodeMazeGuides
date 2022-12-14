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

                    services.AddHttpClient<ILoginApiRepository, LoginApiRepository>();
                    
                    services.AddScoped<LoginHandler>();

                    services.AddHttpClient<IUserApiRepository, UserApiRepository>()
                        .AddHttpMessageHandler<LoginHandler>();
                    
                }).UseConsoleLifetime();

            return builder.Build();
        }
    }
}
