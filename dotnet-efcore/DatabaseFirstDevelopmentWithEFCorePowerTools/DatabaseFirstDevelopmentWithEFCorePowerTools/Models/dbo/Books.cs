
namespace EFCorePowerToolsExample.Models;

public partial class Books
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? AuthorId { get; set; }

    public int? YearPublished { get; set; }

    public virtual Authors? Author { get; set; }

    public virtual ICollection<BooksCategories> BooksCategories { get; set; } = new List<BooksCategories>();
}
