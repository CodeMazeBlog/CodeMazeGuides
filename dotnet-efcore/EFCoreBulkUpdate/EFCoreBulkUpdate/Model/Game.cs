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

    public class FootballGame : Game
    {
        public int FirstHalfTimeScore { get; set; }

        public int SecondHalfTimeScore { get; set; }
    }

    public class BasketballGame : Game
    {
        public int Quarter1Score { get; set; }
        public int Quarter2Score { get;set; }
        public int Quarter3Score { get; set; }
        public int Quarter4Score { get; set; }
    }
}
