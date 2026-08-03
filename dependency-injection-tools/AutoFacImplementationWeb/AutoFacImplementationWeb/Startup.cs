using Autofac;
using Autofac.Extensions.DependencyInjection;

using AutoFacImplementationWeb.Implementation;
using AutoFacImplementationWeb.Interface;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using System;
using System.Linq;

namespace AutoFacImplementationWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddControllersAsServices();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AutoFacImplementationWeb", Version = "v1" });
            });

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterType<PersonBusiness>().As<IPersonBusiness>();
            builder.RegisterType<StringBusiness>().As<IStringBusiness>();
            var controllersTypesInAssembly = typeof(Startup).Assembly.GetExportedTypes()
                .Where(type => typeof(ControllerBase).IsAssignableFrom(type)).ToArray();
            builder.RegisterTypes(controllersTypesInAssembly).PropertiesAutowired();

            return new AutofacServiceProvider(builder.Build());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AutoFacImplementationWeb v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
