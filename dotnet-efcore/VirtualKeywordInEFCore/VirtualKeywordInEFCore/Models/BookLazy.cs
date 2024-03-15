using System.ComponentModel.DataAnnotations;

namespace VirtualKeywordInEFCore.Models
{
    public class BookLazy
    {
        [Key]
        public int BookId { get; set; }
        public string? Title { get; set; }
        public int AuthorId { get; set; }
        public virtual AuthorLazy Author { get; set; }
    }
}
