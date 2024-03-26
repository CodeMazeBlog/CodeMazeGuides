using HandlingCircularRefsWhenWorkingWithJson.Controllers;
using HandlingCircularRefsWhenWorkingWithJson.Services;
using HandlingCircularRefsWhenWorkingWithJson.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

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