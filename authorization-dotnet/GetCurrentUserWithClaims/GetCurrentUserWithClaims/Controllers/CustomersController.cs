using GetCurrentUserWithClaims.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GetCurrentUserWithClaims.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICustomerService _service;

        public CustomersController(IHttpContextAccessor httpContextAccessor, ICustomerService service) 
        {
            _httpContextAccessor = httpContextAccessor;
            _service = service;

            Console.WriteLine("User Id: " + _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier));
            Console.WriteLine("Username: " + _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name));
        }

        [HttpGet, Authorize]
        public IEnumerable<string> Get()
        {
            Console.WriteLine("User Id: " + User.FindFirstValue(ClaimTypes.NameIdentifier));
            Console.WriteLine("Username: " + User.FindFirstValue(ClaimTypes.Name));
            Console.WriteLine("Role: " + User.FindFirstValue(ClaimTypes.Role));
            Console.WriteLine("First name: " + User.FindFirstValue("firstname"));
            Console.WriteLine("Last name: " + User.FindFirstValue("lastname"));

            return _service.GetCustomers();            
        }
    }
}
