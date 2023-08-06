using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.DataLayer.Entities;

namespace TaskManagementSystem.DataLayer.Dtos
{
    public class RegisterResultDto
    {
        public RegisterResultDto(bool succeeded, IEnumerable<string>? errorMessages = null, List<Claim>? claims = null)
        {
            Succeeded = succeeded;
            ErrorMessages = errorMessages;
            Claims = claims;
        }

        public bool Succeeded { get; set; } = true;
        public List<Claim>? Claims { get; set; }
        public IEnumerable<string>? ErrorMessages { get; set; }
    }
}
