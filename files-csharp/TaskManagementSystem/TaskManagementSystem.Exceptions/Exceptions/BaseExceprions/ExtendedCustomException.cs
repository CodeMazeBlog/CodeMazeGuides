using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Exceptions.Constants;

namespace TaskManagementSystem.Exceptions.Exceptions.BaseExceprions
{
    public abstract class ExtendedCustomException : CustomException
    {
        public IEnumerable<string> ErrorMessages { get; set; }

        public ExtendedCustomException(int statusCode, int errorCode, string message, IEnumerable<string> errorMessages) : base(statusCode, errorCode, message)
        {
            ErrorMessages = errorMessages;
        }
    }
}
