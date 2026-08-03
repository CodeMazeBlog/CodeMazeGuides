using GenerateUniqueIDsWithNewId.Contracts;

namespace GenerateUniqueIDsWithNewId.Services.Abstractions;

public interface IOrderService
{
    Task<IEnumerable<OrderDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<OrderDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<OrderDto> CreateAsync(OrderForCreationDto orderForCreationDto, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, OrderForUpdateDto orderForUpdateDto, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
