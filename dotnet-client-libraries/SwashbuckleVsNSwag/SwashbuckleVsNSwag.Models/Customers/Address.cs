using System.ComponentModel.DataAnnotations;

namespace SwashbuckleVsNSwag.Models.Customers
{
    public class Address
    {
        [Required]
        public string? AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        public string? AddressLine3 { get; set; }

        public string? AddressLine4 { get; set; }

        public string? AddressLine5 { get; set; }

        [Required]
        public string? PostalCode { get; set; }

        [Required]
        public string? Country { get; set; }

        [Required]
        public string? City { get; set; }
    }
}