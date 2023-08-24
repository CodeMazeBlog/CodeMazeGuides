namespace MultiTenantApplication.Infrastructure.Repositories;

public class GoodsRepository : IGoodsRepository
{
    private readonly InventoryDbContext _dbContext;

    public GoodsRepository(InventoryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Goods> AddAsync(GoodsDto goodsDto)
    {
        var goods = new Goods { Name = goodsDto.Name, Price = goodsDto.Price };

        await _dbContext.Goods.AddAsync(goods);
        await _dbContext.SaveChangesAsync();

        return goods;
    }

    public async Task<IReadOnlyList<Goods>> GetAllAsync()
    {
        return await _dbContext.Goods.ToListAsync();
    }
}