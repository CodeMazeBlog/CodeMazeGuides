using HandlingCircularRefsWhenWorkingWithJson.Controllers;
using HandlingCircularRefsWhenWorkingWithJson.Services;
using HandlingCircularRefsWhenWorkingWithJson.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

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