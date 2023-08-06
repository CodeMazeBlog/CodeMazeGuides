using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.DataLayer.Entities
{
    internal class ApplicationUser : IdentityUser
    {
        public bool IsActive { get; set; } = true;
    }
}
