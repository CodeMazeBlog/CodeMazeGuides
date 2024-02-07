using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesInCSharp.AdvancedDelegates
{
    public class Error
    {
        public string Message { get; }
        public int StatusCode { get; }
        public Error(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }
        public string GetFullError() => $"Message: {this.Message} StatusCode:{this.StatusCode}";
    }
}
