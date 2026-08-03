using IntroductionToScrutorInDotNet.Customers.Entities;

namespace IntroductionToScrutorInDotNet.Customers.Services.Implementations;

public class CustomerService : ICustomerService
{
    public Customer CreateCustomer(int customerId, string fullName)
    {
        return new Customer()
        {
            CustomerId = customerId,
            FullName = fullName 
        };
    }
}