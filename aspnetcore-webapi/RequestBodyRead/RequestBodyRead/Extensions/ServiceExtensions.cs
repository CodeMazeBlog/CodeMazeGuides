using System;
using RequestBodyRead.Service;
using RequestBodyRead.Service.Contracts;

namespace RequestBodyRead.Extensions
{
	public static class ServiceExtensions
	{
		public static void ConfigureCors(this IServiceCollection services) =>
                services.AddCors(options =>
                {
                    options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
                });

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBufferService, BufferService>();
        }
    }
}

