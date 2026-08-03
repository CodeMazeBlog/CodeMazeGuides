
namespace EFCorePowerToolsExample.Models;

public partial class Authors
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public virtual ICollection<Books> Books { get; set; } = new List<Books>();
}
