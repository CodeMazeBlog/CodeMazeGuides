using System.ComponentModel.DataAnnotations;

namespace VirtualKeywordInEFCore.Models
{
    public class Author_lazy
    {
        [Key]
        public int AuthorId { get; set; }
        public string? FullName { get; set; }
        public virtual ICollection<Book_lazy> Books { get; set; } = new List<Book_lazy>();
    }
}
