using IntroductionToScrutorInDotNET.Models;

namespace IntroductionToScrutorInDotNET.Repositories;

public class OrdersRepository : IRepository<Order>
{
    public Task CreateAsync(Order entity)
    {
        throw new NotImplementedException();
    }
}
