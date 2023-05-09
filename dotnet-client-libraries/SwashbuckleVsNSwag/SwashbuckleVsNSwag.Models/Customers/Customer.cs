using System.ComponentModel.DataAnnotations;

namespace SwashbuckleVsNSwag.Models.Customers
{
    public class Customer
    {
        public Guid CustomerId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public Address? Address { get; set; }
    }
}
