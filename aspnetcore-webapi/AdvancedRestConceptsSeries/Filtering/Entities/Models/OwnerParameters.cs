using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class OwnerParameters : QueryStringParameters
{
    [Range(1900, 2100)]
    public int? MinYearOfBirth { get; set; }

    [Range(1900, 2100)]
    public int? MaxYearOfBirth { get; set; }

    public bool ValidYearRange =>
        MinYearOfBirth is null || MaxYearOfBirth is null || MaxYearOfBirth >= MinYearOfBirth;
}
