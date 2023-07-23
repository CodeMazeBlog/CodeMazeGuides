using CodeMazeShop.Web.Repositories;
using CodeMazeShop.Web.Services;

namespace CodeMazeShop.Web.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddProductCatalogServices(this IServiceCollection services)
        {
            services.AddSingleton<IProductCatalogRepository, ProductCatalogRepository>();
            services.AddSingleton<IProductCatalogService, ProductCatalogService>();            
        }

        public static void AddShoppingCartServices(this IServiceCollection services)
        {
            services.AddSingleton<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddSingleton<IShoppingCartService, ShoppingCartService>();
        }

        public static void AddOrderServices(this IServiceCollection services)
        {
            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton<IOrderService, OrderService>();
        }

        public static void AddPaymentService(this IServiceCollection services)
        {       
            services.AddHttpClient<IPaymentService, PaymentService>(c =>
                c.BaseAddress = new Uri("https://localhost:7049"));

        }
    }
}
