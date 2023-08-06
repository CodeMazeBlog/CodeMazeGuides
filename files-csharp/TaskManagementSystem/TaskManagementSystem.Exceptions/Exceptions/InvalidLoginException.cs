using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Exceptions.Constants;
using TaskManagementSystem.Exceptions.Exceptions.BaseExceprions;

namespace TaskManagementSystem.Exceptions.Exceptions
{
    public class InvalidLoginException : CustomException
    {
        public InvalidLoginException() : base(StatusCodes.Status401Unauthorized, ErrorCodes.InvalidUsernameOrPassword, "Invalid username or password.")
        {
        }
    }
}
