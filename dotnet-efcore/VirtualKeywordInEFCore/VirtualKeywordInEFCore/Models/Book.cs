using System.ComponentModel.DataAnnotations;

namespace VirtualKeywordInEFCore.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string? Title { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
