using Microsoft.AspNetCore.Mvc;
using SwashbuckleVsNSwag.Models.Customers;
using SwashbuckleVsNSwag.Repositories.CustomerRepository;

namespace SwashbuckleVsNSwag.Swashbuckle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerRepository _customers;

        public CustomerController(ILogger<CustomerController> logger, ICustomerRepository customers)
        {
            _logger = logger;
            _customers = customers;
        }

        [HttpGet(Name = "GetCustomerById")]
        public ActionResult<Customer> Get(Guid customerId)
        {
            return _customers.GetById(customerId);
        }

        [HttpPost(Name = "PostCustomer")]
        public ActionResult<Customer> Post(Customer customer)
        {
            _customers.Add(customer);

            return customer;
        }
    }
}