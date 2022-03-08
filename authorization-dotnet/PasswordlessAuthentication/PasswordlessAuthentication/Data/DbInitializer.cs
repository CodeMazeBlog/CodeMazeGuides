using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PasswordlessAuthentication.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(UserManager<IdentityUser> userManager, LoginContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new IdentityUser[]
            {
                new IdentityUser {UserName = "sally", Email = "sally@example.com"},
                new IdentityUser {UserName = "emily", Email = "emily@example.com"},
                new IdentityUser {UserName = "alberto", Email = "alberto@example.com"}
            };
            foreach (IdentityUser u in users)
            {
                await userManager.CreateAsync(u);
            }
            context.SaveChanges();

        }
    }
}
