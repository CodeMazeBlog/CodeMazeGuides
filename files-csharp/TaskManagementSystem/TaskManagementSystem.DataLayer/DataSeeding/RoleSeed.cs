using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.DataLayer.Entities;
using TaskManagementSystem.Domain.Constants;
using TaskManagementSystem.Domain.Enums;

namespace TaskManagementSystem.DataLayer.DataSeeding
{
    internal static class RoleSeed
    {
        public static void AddRoleSeedData(this ModelBuilder builder)
        {
            builder.Entity<ApplicationRole>(entity =>
            {
                entity.HasData(new List<ApplicationRole>
                {
                    new ApplicationRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        RoleId = UserRoles.User,
                        Name = RoleConstants.User,
                        NormalizedName = RoleConstants.User.ToUpper(),
                    },
                    new ApplicationRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        RoleId = UserRoles.Manager,
                        Name = RoleConstants.Manager,
                        NormalizedName = RoleConstants.Manager.ToUpper(),
                    },
                    new ApplicationRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        RoleId = UserRoles.Admin,
                        Name = RoleConstants.Admin,
                        NormalizedName = RoleConstants.Admin.ToUpper(),
                    }
                });
            });
        }
    }
}
