using System.ComponentModel.DataAnnotations;

namespace VirtualKeywordInEFCore.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string? FullName { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
