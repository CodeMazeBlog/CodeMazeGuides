
namespace EFCorePowerToolsExample.Models;

public partial class BooksCategories
{
    public int Id { get; set; }

    public int? BookId { get; set; }

    public int? CategoryId { get; set; }

    public virtual Books? Book { get; set; }

    public virtual Categories? Category { get; set; }
}
