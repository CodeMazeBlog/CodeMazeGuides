using Order.Interfaces;
using Order.Models;

namespace Order.Services;

internal class OrderService(
    IOrderRepository orderRepository,
    IInventoryRabbitMqClient inventoryRabbitMqClient,
    IInventoryRestClient inventoryRestClient) : IOrderService
{
    public async Task AddAsync(OrderDto orderDto)
    {
        foreach (var itemModel in orderDto.Items)
        {
            var item = await inventoryRestClient.GetItem(itemModel.ItemId) ??
                throw new InvalidOperationException($"The requested item '{itemModel.ItemId} was not found.'");

            if (item.Quantity < itemModel.Quantity)
                throw new InvalidOperationException($"There isn't enough stock for item '{itemModel.ItemId}'.");

            itemModel.PricePerUnit = item.Price;
            itemModel.Total = itemModel.Quantity * item.Price;

            inventoryRabbitMqClient.UpdateQuantity(new Inventory.Models.UpdateQuantityDto
            {
                ItemId = itemModel.ItemId,
                Amount = itemModel.Quantity * -1
            });
        }

        orderDto.Total = orderDto.Items.Sum(i => i.Total);

        orderRepository.Add(orderDto);
    }

    public async Task<List<OrderDto>> GetAllAsync()
    {
        var orders = orderRepository.GetAll();

        foreach (var orderItem in orders.SelectMany(i => i.Items))
        {
            var item = await inventoryRestClient.GetItem(orderItem.ItemId) ??
                throw new InvalidOperationException($"The requested item '{orderItem.ItemId} was not found.'");
            orderItem.ItemName = item.Name;
        }

        return orders;
    }
}
