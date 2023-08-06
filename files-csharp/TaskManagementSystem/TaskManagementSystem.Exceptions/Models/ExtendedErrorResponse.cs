using System.Text.Json;
using TaskManagementSystem.Exceptions.Exceptions.BaseExceprions;

namespace TaskManagementSystem.Exceptions.Models
{
    internal class ExtendedErrorResponse : ErrorResponse
    {
        public IEnumerable<string> ErrorMessages { get; set; }
        public ExtendedErrorResponse(ExtendedCustomException exception) : base(exception) 
        {
            ErrorMessages = exception.ErrorMessages;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
