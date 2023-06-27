using IntroductionToScrutorInDotNET.Models;

namespace IntroductionToScrutorInDotNET.Repositories;

public class CustomerRepository : IRepository<Customer>
{
    public Task CreateAsync(Customer entity)
    {
        throw new NotImplementedException();
    }
}
