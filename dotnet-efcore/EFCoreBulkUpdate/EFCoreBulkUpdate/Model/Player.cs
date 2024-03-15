using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreBulkUpdate.Model
{
    public class Player
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public Guid TeamId { get; set; }        
       
        [ForeignKey(nameof(TeamId))]
        public virtual Team Team { get; set; }
    }
}
