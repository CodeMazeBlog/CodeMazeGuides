using MultiTenantApplication.Core.Entities;

namespace MultiTenantApplication.Core.Abstractions;

public interface IGoodsRepository
{
    Task<Goods> AddAsync(GoodsDto goodsDto);

    Task<IReadOnlyList<Goods>> GetAllAsync();
}