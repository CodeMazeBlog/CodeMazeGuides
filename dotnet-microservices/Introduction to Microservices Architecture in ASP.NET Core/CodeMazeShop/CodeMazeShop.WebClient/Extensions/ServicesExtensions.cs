using CodeMazeShop.WebClient.Services;

namespace CodeMazeShop.WebClient.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddProductCatalogServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddHttpClient<IProductCatalogService, ProductCatalogService>(c =>
                c.BaseAddress = new Uri(config["ServiceConfigs:ProductCatalog:Uri"]));
        }

        public static void AddShoppingCartServices(this IServiceCollection services)
        {            
            services.AddSingleton<IShoppingCartService, ShoppingCartService>();
        }

        public static void AddOrderServices(this IServiceCollection services)
        {           
            services.AddSingleton<IOrderService, OrderService>();
        }

        public static void AddPaymentService(this IServiceCollection services)
        {       
            services.AddHttpClient<IPaymentService, PaymentService>(c =>
                c.BaseAddress = new Uri("https://localhost:7049"));

        }
    }
}
