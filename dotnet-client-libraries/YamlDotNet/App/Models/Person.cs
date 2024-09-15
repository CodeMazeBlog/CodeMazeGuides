using System.ComponentModel.DataAnnotations;

namespace App.Models;

public class Person
{
    [Required]
    public string Name { get; set; }

    public int Age { get; set; }
}