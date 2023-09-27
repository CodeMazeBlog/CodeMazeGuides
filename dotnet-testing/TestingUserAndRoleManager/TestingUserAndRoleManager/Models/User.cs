using Microsoft.AspNetCore.Identity;

namespace TestingUserAndRoleManager.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
