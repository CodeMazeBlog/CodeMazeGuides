using System.ComponentModel.DataAnnotations;

namespace EFCoreBulkUpdate.Model
{
    // TPT
    public class Game
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Opponent { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Guid TeamId { get; set; }

        [Required]
        public virtual Team Team { get; set; }
    }
}