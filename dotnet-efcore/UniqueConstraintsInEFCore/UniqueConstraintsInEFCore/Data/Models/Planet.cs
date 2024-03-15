using Microsoft.EntityFrameworkCore;

namespace UniqueConstraintsInEFCore.Data.Models;

[Index(nameof(Name), IsUnique = true)]
public class Planet
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required double Mass { get; set; }
    public required double Radius { get; set; }
}
