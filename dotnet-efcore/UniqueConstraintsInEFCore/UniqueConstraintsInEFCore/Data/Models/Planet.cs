using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace UniqueConstraintsInEFCore.Data.Models;

//[Index(nameof(Name), IsUnique = true)]
public class Planet
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required double Mass { get; set; }
    public required double Radius { get; set; }
}
