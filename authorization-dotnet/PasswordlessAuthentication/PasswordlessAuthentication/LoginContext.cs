using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PasswordlessAuthentication.Models;

namespace PasswordlessAuthentication
{
    public class LoginContext : IdentityDbContext
    {
        public LoginContext(DbContextOptions<LoginContext> options)
            : base(options)
        {
        }
    }
}
