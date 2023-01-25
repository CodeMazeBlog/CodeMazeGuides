using Microsoft.AspNetCore.Identity;

namespace IdentityByExamples.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
