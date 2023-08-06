using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Domain.Constants
{
    public static class RoleConstants
    {
        public const string Admin = "Admin";
        public const string User = "User";
        public const string Manager = "Manager";
        public const string Admin_Manager = "Admin,Manager";
        public const string Admin_Manager_User = "User,Admin,Manager";
    }
}
