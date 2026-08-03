using IntroductionToScrutorInDotNet.Customers.Entities;

namespace IntroductionToScrutorInDotNet.Customers.Services;

public interface ICustomerService
{
    Customer CreateCustomer(int customerId, string fullName);
}