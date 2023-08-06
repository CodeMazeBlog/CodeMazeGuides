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
    public class UserNotFoundException : CustomException
    {
        public UserNotFoundException(string userId) : base(StatusCodes.Status404NotFound, ErrorCodes.UserNotFound, $"User with Id {userId} not found.")
        {
        }
    }
}
