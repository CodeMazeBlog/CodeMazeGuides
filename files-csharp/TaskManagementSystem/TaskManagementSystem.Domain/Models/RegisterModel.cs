using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Enums;

namespace TaskManagementSystem.Domain.Models
{
    public class RegisterModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [EnumDataType(typeof(UserRoles))]
        [Required]
        public UserRoles Role { get; set; }
    }
}
