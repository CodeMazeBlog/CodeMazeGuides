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

        public static void AddShoppingCartServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddHttpClient<IShoppingCartService, ShoppingCartService>(c =>
                c.BaseAddress = new Uri(config["ServiceConfigs:ShoppingCart:Uri"]));
        }

        public static void AddOrderServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddHttpClient<IOrderService, OrderService>(c =>
                c.BaseAddress = new Uri(config["ServiceConfigs:Ordering:Uri"]));
        }       
    }
}
