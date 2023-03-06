using System.Security.Claims;

namespace GetCurrentUserWithClaims.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomerService(IHttpContextAccessor httpContextAccessor) 
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<string> GetCustomers()
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name);

            return new string[] { "John Doe", "Jane Doe" };
        }
    }
}
