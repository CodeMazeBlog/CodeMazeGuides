using CodeMazeShop.Services.Ordering.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeMazeShop.Services.Ordering.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly OrderContext _context;

    public OrderRepository(OrderContext context)
    {
        _context = context; 
    }

    public async Task CreateOrder(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.OrderLineItems.AddRangeAsync(order.LineItems);
        await _context.ShippingDetails.AddAsync(order.ShippingDetails);
        
        await _context.SaveChangesAsync();

    }

    public async Task<Order> GetOrderDetails(string orderId)    
        => await _context
            .Orders
            .Include(o => o.LineItems)
            .Include(o => o.ShippingDetails)
            .FirstOrDefaultAsync(o => o.OrderId == orderId);




    public async Task<List<Order>> GetOrdersForUser(string userId) 
        => await _context
            .Orders
            .Include(o => o.LineItems)
            .Where(o => o.UserId == userId)
            .ToListAsync();

    public async Task UpdateOrderStatus(string orderId, bool isPaymentComplted)
    {
        var order = await _context
            .Orders           
            .FirstOrDefaultAsync(o => o.OrderId == orderId);

        order.OrderPaid = isPaymentComplted;

        await _context.SaveChangesAsync();
    }
}