using System.ComponentModel.DataAnnotations;

namespace ApiControllerAttributeInWebApi.Models
{
    public class Customer
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? Country { get; set; }

        public DateTime? LastOrder { get; set; }

        public bool IsActive { get; set; }
    }
}
