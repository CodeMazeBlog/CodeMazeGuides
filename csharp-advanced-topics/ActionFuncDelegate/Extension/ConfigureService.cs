using ActionFuncDelegate.Context;
using ActionFuncDelegate.Implementation;
using ActionFuncDelegate.Service;
using Microsoft.EntityFrameworkCore;

namespace ActionFuncDelegate.Extension
{
    public static class ConfigureService
    {
        public static void AddDepencies(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<AppDbContext>(opts => opts.
            UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            service.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
