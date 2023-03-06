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

            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name);
        }

        [HttpGet, Authorize]
        public IEnumerable<string> Get()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var role = User.FindFirstValue(ClaimTypes.Role);
            var firstName = User.FindFirstValue("firstname");
            var lastName = User.FindFirstValue("lastname");

            return _service.GetCustomers();            
        }
    }
}
