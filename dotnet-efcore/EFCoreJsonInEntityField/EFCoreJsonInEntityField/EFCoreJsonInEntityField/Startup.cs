
using EFCoreJsonInEntityField.Mapping;
using EFCoreJsonInEntityField.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCoreJsonInEntityField
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration) 
        {
            this._configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<OrderContext>(options => options.UseSqlServer(ConnectionString));
            services.AddControllers().AddNewtonsoftJson(); ;
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
           
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
