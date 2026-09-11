using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Account")] 
    public class Account 
    {
        public Guid AccountId { get; set; }

        [Required(ErrorMessage = "Date created is required")] 
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Account type is required")] 
        public string? AccountType { get; set; }

        [ForeignKey(nameof(Owner))]
        public Guid OwnerId { get; set; }
        public Owner? Owner { get; set; }
    }
}
