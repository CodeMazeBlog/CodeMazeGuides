using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TaskManagementSystem.Exceptions.Exceptions.BaseExceprions;

namespace TaskManagementSystem.Exceptions.Models
{
    internal class ErrorResponse
    {
        public ErrorResponse() 
        {
            StatusCode = 500;
            ErrorCode = 5000;
            Message = "An unexpected error has occured.";
        }

        public ErrorResponse(CustomException customException) 
        { 
            StatusCode = customException.StatusCode;
            Message = customException.Message;
            ErrorCode = customException.ErrorCode;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public int ErrorCode { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
