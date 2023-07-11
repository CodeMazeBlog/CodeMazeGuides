using IntroductionToScrutorInDotNet.Customers.Services;
using IntroductionToScrutorInDotNet.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IntroductionToScrutorInDotNet.Controllers;

[Route("[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost]
    public IActionResult CreateCustomer(User user)
    {
        var fullName = string.Join(' ', user.FirstName, user.LastName);
        var customerId = Random.Shared.Next(1000);

        return Created(
            $"/Customers/{customerId}",
            _customerService.CreateCustomer(customerId, fullName)
        );
    }
}