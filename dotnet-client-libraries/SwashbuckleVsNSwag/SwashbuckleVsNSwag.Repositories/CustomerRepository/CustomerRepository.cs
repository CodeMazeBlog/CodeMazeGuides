using SwashbuckleVsNSwag.Models.Customers;

namespace SwashbuckleVsNSwag.Repositories.CustomerRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Dictionary<Guid, Customer> _repository = new Dictionary<Guid, Customer>();

        public Customer GetById(Guid id)
        {
            return _repository[id];
        }

        public void Add(Customer customer)
        {
            customer.CustomerId = Guid.NewGuid();

            _repository[customer.CustomerId] = customer;
        }

        public void Remove(Guid id)
        {
            _repository.Remove(id);
        }
    }
}