using HandlingCircularRefsWhenWorkingWithJson.Services.Interfaces;
using HandlingCircularRefsWhenWorkingWithJson.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using HandlingCircularRefsWhenWorkingWithJson.Controllers;

namespace Tests
{
    public class TestStartupWithPreserve
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure services needed for testing
            services.AddControllers()
                    .AddApplicationPart(typeof(EmployeeController).Assembly)
                    .AddJsonOptions(options =>
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

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