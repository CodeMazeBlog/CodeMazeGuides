
namespace EFCorePowerToolsExample.Models;

public partial class Categories
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<BooksCategories> BooksCategories { get; set; } = new List<BooksCategories>();
}
