using CodeMazeShop.Integration.Messages;
using CodeMazeShop.Services.Ordering.Entities;
using CodeMazeShop.Services.Ordering.Repositories;

namespace CodeMazeShop.Services.Ordering;

public class OrderCreatorService : IOrderCreatorService
{
    private readonly IOrderRepository _orderRepository;

    public OrderCreatorService(IOrderRepository orderRepository)
    {
        _orderRepository= orderRepository;  
    }
    public async Task<Guid> CreateOrder(CartCheckoutMessage cartCheckoutMessage)
    {
        try
        {
            var orderId = Guid.NewGuid();

            var shippingDetails = new ShippingDetails
            {
                ShippingDetailsId = Guid.NewGuid().ToString(),
                FirstName = cartCheckoutMessage.FirstName,
                LastName = cartCheckoutMessage.LastName,
                Address = cartCheckoutMessage.Address,
                City = cartCheckoutMessage.City,
                Country = cartCheckoutMessage.Country,
                Email = cartCheckoutMessage.Email,
                ZipCode = cartCheckoutMessage.ZipCode,
                OrderId = orderId.ToString()
            };

            var order = new Order
            {
                OrderId = orderId.ToString(),
                ShippingDetails = shippingDetails,
                OrderPaid = false,
                OrderTotal = cartCheckoutMessage.OrderTotal,
                OrderPlaced = DateTime.UtcNow,
                UserId = cartCheckoutMessage.UserId.ToString()
            };

            foreach (var lineItem in cartCheckoutMessage.LineItems)
            {
                order.LineItems.Add(new OrderLineItem
                {
                    OrderLineItemId = Guid.NewGuid().ToString(),
                    Price = lineItem.Price,
                    Quantity = lineItem.Quantity,
                    OrderId = orderId.ToString(),
                    ProductId = lineItem.ProductId.ToString()
                });
            }

            await _orderRepository.CreateOrder(order);

            return orderId;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return Guid.Empty;
        }
    }
}
