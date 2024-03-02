using System.ComponentModel.DataAnnotations;

namespace VirtualKeywordInEFCore.Models
{
    public class Book_lazy
    {
        [Key]
        public int BookId { get; set; }
        public string? Title { get; set; }
        public int AuthorId { get; set; }
        public virtual Author_lazy Author { get; set; }
    }
}
