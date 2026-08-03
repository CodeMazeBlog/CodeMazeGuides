using System.ComponentModel.DataAnnotations;

namespace EFCoreBulkUpdate.Model
{
    public class Team
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int YearFounded { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<Player> Players { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
