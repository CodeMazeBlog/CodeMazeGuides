using System.ComponentModel.DataAnnotations;

namespace VirtualKeywordInEFCore.Models
{
    public class AuthorLazy
    {
        [Key]
        public int AuthorId { get; set; }
        public string? FullName { get; set; }
        public virtual ICollection<BookLazy> Books { get; set; } = new List<BookLazy>();
    }
}
