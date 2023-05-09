using SwashbuckleVsNSwag.Models.Customers;

namespace SwashbuckleVsNSwag.Repositories.CustomerRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Dictionary<Guid, Customer> _repository = new Dictionary<Guid, Customer>();

        public CustomerRepository()
        {
            var guid = new Guid("8e282cc4-71bd-4ffd-b63c-05e91ba79ad1");

            _repository.Add(
                guid,
                new Customer
                {
                    CustomerId = new Guid("8e282cc4-71bd-4ffd-b63c-05e91ba79ad1"),
                    Name = "John Smith"
                });
        }

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