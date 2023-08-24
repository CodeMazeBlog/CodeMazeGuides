using Microsoft.AspNetCore.Mvc;

namespace ExtractCustomHeader.DTO
{
    public class HeaderDTO
    {
        [FromHeader]
        public string FirstName { get; set; } = string.Empty;
        [FromHeader]
        public string LastName { get; set; } = string.Empty;
    }
}
