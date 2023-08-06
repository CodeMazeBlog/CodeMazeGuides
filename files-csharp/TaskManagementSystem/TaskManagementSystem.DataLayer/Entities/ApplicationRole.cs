using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Enums;

namespace TaskManagementSystem.DataLayer.Entities
{
    internal class ApplicationRole : IdentityRole
    {
        public UserRoles RoleId { get; set; } = UserRoles.User;
    }
}
