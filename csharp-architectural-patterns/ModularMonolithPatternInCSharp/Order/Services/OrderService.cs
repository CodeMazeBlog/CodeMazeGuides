using Order.Interfaces;
using Order.Models;

namespace Order.Services;

public class OrderService(
    IOrderRepository orderRepository,
    IInventoryRabbitMqClient inventoryRabbitMqClient,
    IInventoryRestClient inventoryRestClient) : IOrderService
{
    private readonly IOrderRepository _orderRepository = orderRepository;
    private readonly IInventoryRabbitMqClient _inventoryRabbitMqClient = inventoryRabbitMqClient;
    private readonly IInventoryRestClient _inventoryRestClient = inventoryRestClient;

    public async Task AddAsync(OrderDto orderDto)
    {
        foreach (var itemModel in orderDto.Items)
        {
            var item = await _inventoryRestClient.GetItem(itemModel.ItemId) ??
                throw new InvalidOperationException($"The requested item '{itemModel.ItemId} was not found.'");

            if (item.Quantity < itemModel.Quantity)
                throw new InvalidOperationException($"There isn't enough stock for item '{itemModel.ItemId}'. Requested Amount: {itemModel.Quantity}, Available Amount: {item.Quantity}");

            itemModel.PricePerUnit = item.Price;
            itemModel.Total = itemModel.Quantity * item.Price;

            _inventoryRabbitMqClient.UpdateQuantity(new Inventory.Models.UpdateQuantityDto
            {
                ItemId = itemModel.ItemId,
                Amount = itemModel.Quantity * -1
            });
        }

        orderDto.Total = orderDto.Items.Sum(i => i.Total);

        _orderRepository.Add(orderDto);
    }

    public async Task<List<OrderDto>> GetAllAsync()
    {
        var orders = _orderRepository.GetAll();

        foreach (var orderItem in orders.SelectMany(i => i.Items))
        {
            var item = await _inventoryRestClient.GetItem(orderItem.ItemId) ??
                throw new InvalidOperationException($"The requested item '{orderItem.ItemId} was not found.'");
            orderItem.ItemName = item.Name;
        }

        return orders;
    }
}
