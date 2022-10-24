﻿using CodeMazeShop.DataContracts.Ordering;

namespace CodeMazeShop.WebClient.Services;

public interface IOrderService
{
    Task<List<Order>> GetOrdersForUser(Guid userId);

    Task<Order> GetOrderDetails(Guid orderId);

    Task CreateOrder(Order order);

    Task UpdateOrderStatus(Guid orderId, bool isPaymentComplted);
}
