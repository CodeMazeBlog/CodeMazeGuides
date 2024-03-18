using HandlingCircularRefsWhenWorkingWithJson.Services.Interfaces;
using HandlingCircularRefsWhenWorkingWithJson.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using HandlingCircularRefsWhenWorkingWithJson.Controllers;

namespace Tests
{
    public class TestStartupWithIgnoreCycles
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                    .AddApplicationPart(typeof(EmployeeController).Assembly)
                    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

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