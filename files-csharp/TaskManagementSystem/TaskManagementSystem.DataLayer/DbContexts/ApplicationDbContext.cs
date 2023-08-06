using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using TaskManagementSystem.DataLayer.DataSeeding;
using TaskManagementSystem.DataLayer.Entities;

namespace TaskManagementSystem.DataLayer.DbContexts
{
    internal class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<UserTask> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.AddRoleSeedData();
            base.OnModelCreating(builder);
        }
    }
}
