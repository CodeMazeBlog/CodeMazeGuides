using Inventory.Models;

namespace Order.Interfaces;

public interface IInventoryRabbitMqClient
{
    void UpdateQuantity(UpdateQuantityDto updateQuantityDto);
}
