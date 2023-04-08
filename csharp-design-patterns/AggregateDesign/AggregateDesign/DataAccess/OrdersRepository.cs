using AggregateDesign.Domain;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AggregateDesign.DataAccess;

public class OrdersRepository : IOrdersRepository
{
    private readonly OrdersDbContext _dbContext;
    private readonly IMapper _mapper;

    public OrdersRepository(OrdersDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<Order?> GetByIdAsync(long id)
    {
        var dataModel = await _dbContext.Orders
            .Include(x => x.Items)
            .FirstAsync(x => x.OrderId == id);

        if (dataModel is null)
            return null;

        var entity = _mapper.Map<OrderModel, Order>(dataModel);
        return entity;
    }

    public async Task<Order> CreateAsync(Order entity)
    {
        var dataModel = _mapper.Map<Order, OrderModel>(entity);
        var entry = _dbContext.Add(dataModel);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<OrderModel, Order>(entry.Entity);
    }

    public async Task<Order> UpdateAsync(Order entity)
    {
        var dataModel = _mapper.Map<Order, OrderModel>(entity);
        var attached = await _dbContext.Orders
            .Include(x => x.Items)
            .SingleAsync(x => x.OrderId == entity.OrderId);

        _dbContext.Entry(attached).State = EntityState.Detached;
        foreach (var item in attached.Items.ToList())
            _dbContext.Entry(item).State = EntityState.Detached;

        var entry = _dbContext.Attach(dataModel);

        await _dbContext.SaveChangesAsync();

        return _mapper.Map<OrderModel, Order>(entry.Entity);
    }
}
