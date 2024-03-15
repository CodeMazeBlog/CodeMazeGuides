
namespace EFCorePowerToolsExample.Models;

public partial class BookDetails
{
    public int BookId { get; set; }

    public string? BookName { get; set; }

    public int? YearPublished { get; set; }

    public string? AuthorFirstName { get; set; }

    public string? AuthorLastName { get; set; }

    public int? CategoryId { get; set; }

    public string? CategoryName { get; set; }
}
