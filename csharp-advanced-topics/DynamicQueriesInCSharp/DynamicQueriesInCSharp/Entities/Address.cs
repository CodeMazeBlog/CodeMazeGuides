using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicQueriesInCSharp.Entities
{
    public class Address
    {
        public string? Country { get; set; }

        public string? State { get; set; }

        public string? City { get; set; }

        public string? AddressLine { get; set; }
    }
}
