using Microsoft.AspNetCore.Mvc;
using MockingIOptions.Services;

namespace MockingIOptions.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet()]
        public string Get()
        {
            return _customerService.GetConnectionString();
        }
    }
}