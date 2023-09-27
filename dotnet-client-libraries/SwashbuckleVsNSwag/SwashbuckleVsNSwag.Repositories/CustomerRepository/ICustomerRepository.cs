using SwashbuckleVsNSwag.Models.Customers;

namespace SwashbuckleVsNSwag.Repositories.CustomerRepository
{
    public interface ICustomerRepository
    {
        Customer GetById(Guid id);

        void Add(Customer customer);

        void Remove(Guid id);
    }
}