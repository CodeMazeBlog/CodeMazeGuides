using IntroductionToScrutorInDotNET.Models;

namespace IntroductionToScrutorInDotNET.Services;

public interface ICustomerService
{
    void Create(Customer newCustomer);
}