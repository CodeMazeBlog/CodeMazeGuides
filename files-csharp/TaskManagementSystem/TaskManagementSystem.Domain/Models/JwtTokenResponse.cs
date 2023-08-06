using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Domain.Models
{
    public class JwtTokenResponse
    {
        public JwtTokenResponse(string token, DateTime expiresOn) 
        {
            Token = token;
            ExpiresOn = expiresOn;
        }

        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}
