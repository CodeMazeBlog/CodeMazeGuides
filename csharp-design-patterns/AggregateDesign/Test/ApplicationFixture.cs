using AggregateDesign.DataAccess;
using AggregateDesign.Domain;
using AggregateDesign.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace Test
{
    public class ApplicationFixture : IDisposable
    {
        public ServiceProvider ServiceProvider { get; }

        public ApplicationFixture()
        {
            ServiceProvider = new ServiceCollection()
                .AddAutoMapper(typeof(OrderMappingProfile))
                .AddDbContext<OrdersDbContext>()
                .AddTransient<IOrdersRepository, OrdersRepository>()
                .BuildServiceProvider();
        }

        public void Dispose()
        {
            ServiceProvider.Dispose();
        }
    }
}
