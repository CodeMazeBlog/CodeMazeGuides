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
            Console.WriteLine("User Id: " + _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier));
            Console.WriteLine("Username: " + _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name));

            return new string[] { "John Doe", "Jane Doe" };
        }
    }
}
