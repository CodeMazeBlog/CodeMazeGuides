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
    public class RegisterFailedException : ExtendedCustomException
    {
        public RegisterFailedException(IEnumerable<string>? errorMessages) : base(StatusCodes.Status400BadRequest, ErrorCodes.RegisterFailed, "Failed To Register User.", errorMessages)
        { 
        }
    }
}
