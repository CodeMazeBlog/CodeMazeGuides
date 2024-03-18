using HandlingCircularRefsWhenWorkingWithJson.Services.Interfaces;
using HandlingCircularRefsWhenWorkingWithJson.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using HandlingCircularRefsWhenWorkingWithJson.Controllers;

namespace Tests.StartUps
{
    public class TestStartupWithoutReferenceHandler
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                    .AddApplicationPart(typeof(EmployeeController).Assembly);

            services.AddScoped<IEmployeeService, EmployeeService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}