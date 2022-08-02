using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PasswordlessAuthentication;

public class LoginContext : IdentityDbContext
{
    public LoginContext(DbContextOptions<LoginContext> options)
        : base(options)
    {
    }
}
