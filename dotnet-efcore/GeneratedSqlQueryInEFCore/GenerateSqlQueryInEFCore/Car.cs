using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenerateSqlQueryInEFCore;

public class Car
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? Brand { get; set; }

    public string? Model { get; set; }

    public int Year { get; set; }

    public string? Name { get; set; }
}