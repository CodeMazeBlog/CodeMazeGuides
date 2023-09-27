using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("account")] 
    public class Account 
    {
        [Column("AccountId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Date created is required")] 
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Account type is required")] 
        public string? AccountType { get; set; }

        [ForeignKey(nameof(Owner))]
        public Guid OwnerId { get; set; }
        public Owner? Owner { get; set; }
    }
}
