using AggregateDesign.DataAccess;
using AggregateDesign.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Test
{
    [Collection("Application collection")]
    public class OrderAggregateLiveTest
    {
        private ApplicationFixture _fixture;

        public OrderAggregateLiveTest(ApplicationFixture fixture    )
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task WhenCreatedOrderIsSaved_ThenIsWrittenToDatabase()
        {
            IOrdersRepository ordersRepository = _fixture.ServiceProvider.GetRequiredService<IOrdersRepository>();
            Order order = new();

            order.AddItem("Cloudsoft Women's Running Shoes", 1, 59.99M);
            order.AddItem("Gildone Men's Crew T-Shirt", 3, 18.99M);
            order.AddPayment(100.0M);

            var created = await ordersRepository.CreateAsync(order);
        }

        [Fact]
        public async Task WhenReadOrderIsUpdated_ThenUpdatesAreWritten()
        {
            IOrdersRepository ordersRepository = _fixture.ServiceProvider.GetRequiredService<IOrdersRepository>();

            // Create an order.
            Order order = new();
            order.AddItem("Enameled Cast Iron Covered Dutch Oven", 1, 76.35M);
            order.AddItem("Skillet with Red Silicone Hot Handle Holder, 12-inch", 1, 29.90M);
            var created = await ordersRepository.CreateAsync(order);

            // Read the created order from database and update it.
            Order? readOrder = await ordersRepository.GetByIdAsync(created.OrderId);
            Assert.NotNull(readOrder);

            readOrder.AddQuantity("Skillet with Red Silicone Hot Handle Holder, 12-inch", 1);
            readOrder.AddPayment(100.0M);
            await ordersRepository.UpdateAsync(readOrder);

            // Read the updated order and assert the changes.
            var updatedOrder = await ordersRepository.GetByIdAsync(readOrder.OrderId);
            Assert.NotNull(updatedOrder);
            Assert.Equal(100.0M, updatedOrder?.PaidAmount);
            Assert.Equal(2, (int?)updatedOrder?.Items?.FirstOrDefault(x => x.ItemName == "Skillet with Red Silicone Hot Handle Holder, 12-inch")?.Quantity);
        }

        [Fact]
        public async Task WhenReadOrderIsRetrieved_ThenSameDataIsRead()
        {
            IOrdersRepository ordersRepository = _fixture.ServiceProvider.GetRequiredService<IOrdersRepository>();

            // Create an order.
            Order order = new();
            order.AddItem("Enameled Cast Iron Covered Dutch Oven", 1, 76.35M);
            order.AddItem("Skillet with Red Silicone Hot Handle Holder, 12-inch", 1, 29.90M);
            var created = await ordersRepository.CreateAsync(order);

            // Read the created order from database.
            Order? readOrder = await ordersRepository.GetByIdAsync(created.OrderId);
            Assert.NotNull(readOrder);
            Assert.Equal(2, readOrder.Items.Count);
            Assert.Collection(readOrder.Items,
                item => Assert.Equal("Enameled Cast Iron Covered Dutch Oven", item.ItemName),
                item => Assert.Equal("Skillet with Red Silicone Hot Handle Holder, 12-inch", item.ItemName));
        }
    }
}