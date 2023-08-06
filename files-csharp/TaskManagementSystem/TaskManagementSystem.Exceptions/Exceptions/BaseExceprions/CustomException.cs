using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Exceptions.Exceptions.BaseExceprions
{
    public abstract class CustomException : Exception
    {
        public int StatusCode { get; set; }
        public int ErrorCode { get; set; }

        public CustomException(int statusCode, int errorCode, string message) : base(message)
        {
            StatusCode = statusCode;
            ErrorCode = errorCode;
        }
    }
}
