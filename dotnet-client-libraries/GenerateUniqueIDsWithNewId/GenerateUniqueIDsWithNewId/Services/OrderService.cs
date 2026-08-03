using GenerateUniqueIDsWithNewId.Contracts;
using GenerateUniqueIDsWithNewId.Data;
using GenerateUniqueIDsWithNewId.Data.Models;
using GenerateUniqueIDsWithNewId.Services.Abstractions;
using MassTransit;

namespace GenerateUniqueIDsWithNewId.Services;

public class OrderService(IUnitOfWork unitOfWork) : IOrderService
{
    public async Task<OrderDto> CreateAsync(
        OrderForCreationDto orderForCreationDto, 
        CancellationToken cancellationToken = default)
    {
        var order = new Order
        {
            Id = NewId.NextSequentialGuid(),
            CustomerName = orderForCreationDto.CustomerName,
            Products = orderForCreationDto.Products,
            TotalAmount = orderForCreationDto.TotalAmount,
        };

        unitOfWork.OrderRepository.Insert(order);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new OrderDto
        {
            Id = order.Id,
            CustomerName = order.CustomerName,
            Products = order.Products,
            TotalAmount = order.TotalAmount,
        };
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var order = await unitOfWork.OrderRepository
            .GetByIdAsync(id, cancellationToken)
            ?? throw new Exception("Order not found!");

        unitOfWork.OrderRepository.Remove(order);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<OrderDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var orders = await unitOfWork.OrderRepository
            .GetAllAsync(cancellationToken);

        var orderDtos = new List<OrderDto>();

        foreach (var order in orders)
        {
            orderDtos.Add(new OrderDto
            {
                Id = order.Id,
                CustomerName = order.CustomerName,
                Products = order.Products,
                TotalAmount = order.TotalAmount
            });
        }

        return orderDtos;
    }

    public async Task<OrderDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var order = await unitOfWork.OrderRepository
            .GetByIdAsync(id, cancellationToken)
            ?? throw new Exception("Order not found!");

        return new OrderDto
        {
            Id = order.Id,
            CustomerName = order.CustomerName,
            Products = order.Products,
            TotalAmount = order.TotalAmount
        };
    }

    public async Task UpdateAsync(Guid id, OrderForUpdateDto orderForUpdateDto, CancellationToken cancellationToken = default)
    {
        var order = await unitOfWork.OrderRepository
            .GetByIdAsync(id, cancellationToken)
            ?? throw new Exception("Order not found!");

        order.CustomerName = orderForUpdateDto.CustomerName;
        order.Products = orderForUpdateDto.Products;
        order.TotalAmount = orderForUpdateDto.TotalAmount;

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
